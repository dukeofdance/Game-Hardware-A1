#define DT1 8
#define DT2 12
#define DT3 4
#define DT4 2
#define DT5 7

float curState1;
float curState2;
float curState3;
float curState4;
float curState5;

float laState1;
float laState2;
float laState3;
float laState4;
float laState5;

String currentDir ="";
String currentDir2="";
String currentDir3="";
String currentDir4="";
String currentDir5="";

void setup() 
{
  Serial.begin(9500);
  pinMode(A1, INPUT);
  pinMode(A2, INPUT);
  pinMode(A3, INPUT);
  pinMode(A4, INPUT);
  pinMode(A5, INPUT);

  pinMode(DT1, INPUT);
  pinMode(DT2, INPUT);

  pinMode(9,OUTPUT);
  
  laState1 = digitalRead(A1);
  laState2 = digitalRead(A2);
  laState3 = digitalRead(A3);
  laState4 = digitalRead(A4);
  laState5 = digitalRead(A5);

}

void loop()
{
  // Read the current state of CLK
  curState1 = digitalRead(A1);
  curState2 = digitalRead(A2);
  curState3 = digitalRead(A3);
  curState4 = digitalRead(A4);
  curState5 = digitalRead(A5);


  // If last and current state of CLK are different, then pulse occurred
  // React to only 1 state change to avoid double count
  if (curState1 != laState1  && curState1 == 1){

    // If the DT state is different than the CLK state then
    // the encoder is rotating CCW so decrement
    if (digitalRead(DT1) != curState1) {
      currentDir =":CCW";
      digitalWrite(9,LOW); //LED off
    } else {
      // Encoder is rotating CW so increment
      currentDir =":CW";
      digitalWrite(9,HIGH);//LED on
    }
     if (analogRead(A1) > 0) {
        Serial.print("A1:");
        Serial.print(analogRead(A1));
        Serial.println(currentDir);
    }
  }
  //Lugnut 2 direction
  if (curState2 != laState2  && curState2 == 1){
    if (digitalRead(DT2) != curState2) {
      currentDir2 =":CCW";
    } else {
      currentDir2 =":CW";
    }
     if (analogRead(A2) > 0) {
        Serial.print("A2:");
        Serial.print(analogRead(A2));
        Serial.println(currentDir2);
    }
  }
  //Lugnut 3 direction
  if (curState3 != laState3  && curState3 == 1){
    if (digitalRead(DT3) != curState3) {
      currentDir3 =":CCW";
    } else {
      currentDir3 =":CW";
    }
    
  if (analogRead(A3) > 0) {
        Serial.print("A3:");
        Serial.print(analogRead(A3));
        Serial.println(currentDir3);
    }
  }
  //Lugnut 4 direction
  if (curState4 != laState4  && curState4 == 1){
    if (digitalRead(DT4) != curState4) {
      currentDir4 =":CCW";
    } else {
      currentDir4 =":CW";
    }
      if (analogRead(A4) > 0) {
        Serial.print("A4:");
        Serial.print(analogRead(A4));
        Serial.println(currentDir4);
    }
  }
  //Lugnut 5 direction
  if (curState5 != laState5  && curState5 == 1){
    if (digitalRead(DT5) != curState5) {
      currentDir5 =":CCW";
    } else {
      currentDir5 =":CW";
    }
     if (analogRead(A5) > 0) {
        Serial.print("A5:");
        Serial.print(analogRead(A5));
        Serial.println(currentDir5);
    }
  }
  // Remember last CLK state
  laState1 = curState1;
  laState2 = curState2;
  laState3 = curState3;
  laState4 = curState4;
  laState5 = curState5;
    
 

 
  
}
