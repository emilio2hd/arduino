Exibe dados do clima em lcd e aplicação C# monta histórico das leituras
======================================

Projeto usa o leitor DHT11 de temperatura e umidade. 
A aplicação C# processa a string enviada pelo arduino e adiciona os dados numa lista.
O arduino e exibe os dados em um LCD 16x2 e quando recebe um determinado comando, imprime os dados na serial no formato json.

**Resposta para leitura com sucesso**
```json
  "\x02{"umidade": 68, "temperatura": 25}\x03"
```    

**Resposta para leitura com erro**
```json
"\x02{"erro": -1}\x03"
```

**OBS:** Caso o FormPrincipal apresente erro na hora de abrir o projeto, basta compilar a solução e abrir novamente o form.

## Libraries:
 * DHT11 Temperature & Humidity Sensor library for Arduino (veio no kit que comprei) - http://www.aliexpress.com/store/226959
 * Microsoft .NET Framework 4
 
## Outros
 * fritzing (para ver o esquema do circuito) - http://fritzing.org/home/
