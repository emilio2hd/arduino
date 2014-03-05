#include <LiquidCrystal.h>
#include <DHT11.h>

#define DHT11PIN                13
#define DHTLIB_ERROR_UNKNOWN	-3

#define STX  "\x02"  //ASCII-Code 02, inicio de texto
#define ETX  "\x03"  //ASCII-Code 03, fim de texto

#define LIDO_COM_SUCESSO                     0
#define SEM_DADOS_DISPONIVEIS_NA_SERIAL      250
#define COMANDO_INCOMPLETO                   -1

#define CMD_LER_CLIMA "LC#" 

boolean possuiErro = false;
boolean deveEscreveNaSerial = false;
LiquidCrystal lcd(2, 3, 4, 5, 6, 7);
dht11 DHT11;

void setup() {
  Serial.begin(9600);
  lcd.begin(16, 2);
  lcd.clear();
  lcd.setCursor(0, 0);
}

void loop() {
  String commando = "";
  int resultadoDaLeitura = 0;
  
  resultadoDaLeitura = leiaComandoDaSerial(&commando);  
  lcd.setCursor(0, 0);
  
  if(resultadoDaLeitura == LIDO_COM_SUCESSO){
    if(commando == CMD_LER_CLIMA){
      deveEscreveNaSerial = true;
    }
  } 
  
  int chk = DHT11.read(DHT11PIN);
  
  if(chk == DHTLIB_OK){    
    imprimaDados();
    possuiErro = false;
  } else{
    possuiErro = true;
    imprimaErro(chk);    
  }
    
  delay(1000);
}

int leiaComandoDaSerial(String *commando){  
  int statusLeitura = LIDO_COM_SUCESSO;
  
  if (Serial.available()) {
     char serialInByte;
     
     do{
       serialInByte = Serial.read();
       *commando = *commando + serialInByte;
     }while(serialInByte != '#' && Serial.available());
     
     if(serialInByte != '#') {
       statusLeitura = COMANDO_INCOMPLETO;
     }
  }else{
    statusLeitura = SEM_DADOS_DISPONIVEIS_NA_SERIAL;
  }
  
  return statusLeitura;
}

void imprimaDados(){
  if(possuiErro == true) limpaDisplay();
  
  lcd.print("Umidade     ");
  lcd.print(DHT11.humidity);
  lcd.print(" %");
  lcd.setCursor(0, 1);
  lcd.print("Temperatura ");
  lcd.print(DHT11.temperature);
  lcd.write(B11011111);
  lcd.print("C");
  
  if(deveEscreveNaSerial){
    Serial.print(STX);
    Serial.print("{");
    Serial.print("\"umidade\":");
    Serial.print(DHT11.humidity);
    Serial.print(",\"temperatura\":");
    Serial.print(DHT11.temperature);
    Serial.print("}");
    Serial.print(ETX);
    deveEscreveNaSerial = false;
  }
}

void imprimaErro(int chk){
  limpaDisplay();
  
  if(deveEscreveNaSerial){
    Serial.print(STX);
    Serial.print("{");
    Serial.print("\"erro\":");
  }
  
  switch (chk) {
    case DHTLIB_ERROR_CHECKSUM: 
      lcd.print("Erro de integridade");       
      if(deveEscreveNaSerial) Serial.print(DHTLIB_ERROR_CHECKSUM);
      break;
    case DHTLIB_ERROR_TIMEOUT: 
      lcd.print("Erro de time out"); 
      if(deveEscreveNaSerial) Serial.print(DHTLIB_ERROR_TIMEOUT);
      break;
    default: 
      lcd.print("Erro desconhecido");
      if(deveEscreveNaSerial) Serial.print(DHTLIB_ERROR_UNKNOWN);
  }
  
  if(deveEscreveNaSerial){  
    Serial.print("}");
    Serial.print(ETX);
    deveEscreveNaSerial = false;
  }
}

void limpaDisplay(){
  lcd.clear();
  lcd.setCursor(0, 0); 
}
