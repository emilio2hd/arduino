#include "TimerOne.h"
#include "Ultrasonic.h"

const int ledVPin = 8;
const int ledAPin = 9;
const int PIRPin = 2;
const int USTrigPin = 11;
const int USEchoPin = 10;
const int buzzerPin = 3;
const int distanciaMinima = 90;

int sensorState = 0;
Ultrasonic ultrasonic(USTrigPin, USEchoPin);

void setup() {                
  pinMode(ledVPin, OUTPUT);     
  pinMode(ledAPin, OUTPUT);
  pinMode(PIRPin, INPUT);     
  pinMode(buzzerPin, OUTPUT); 
  
  Timer1.initialize(500000);
  Timer1.attachInterrupt(inverterEstadoLed);
}

void inverterEstadoLed() {
    digitalWrite(ledAPin, !digitalRead(ledAPin));
}

void loop() {
  sensorState = digitalRead(PIRPin);
  
  if (sensorState == HIGH) {     
    digitalWrite(ledVPin, HIGH);
    confereDistancia();
  }  else {
    digitalWrite(ledVPin, LOW); 
  }
}

void confereDistancia(){
  int distancia = ultrasonic.Ranging(CM);
  
  if(distancia < distanciaMinima){
    tocaAlarmeAviso();
  }
}

void tocaAlarmeAviso(){
 for(int i = 0; i < 5; i++){
    digitalWrite(buzzerPin,HIGH);
    delay(200);
    digitalWrite(buzzerPin,LOW);
    delay(200);
  }
}
