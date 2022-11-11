#define CLK1 A1
#define DT1 7
int counter = 0;
float currentStateCLK;
float lastStateCLK;
String currentDir ="";
unsigned long lastTime = 0;

void setup() 
{
  Serial.begin(9500);
  pinMode(CLK1, INPUT);
  pinMode(A2, INPUT);
  pinMode(A3, INPUT);
  pinMode(A4, INPUT);
  pinMode(A5, INPUT);

  pinMode(DT1, INPUT);

  pinMode(9,OUTPUT);
  
  lastStateCLK = digitalRead(CLK1);
}

void loop()
{
  // Read the current state of CLK
  currentStateCLK = digitalRead(CLK1);

  // If last and current state of CLK are different, then pulse occurred
  // React to only 1 state change to avoid double count
  if (currentStateCLK != lastStateCLK  && currentStateCLK == 1){

    // If the DT state is different than the CLK state then
    // the encoder is rotating CCW so decrement
    if (digitalRead(DT1) != currentStateCLK) {
      currentDir =":CCW";
      digitalWrite(9,LOW);
    } else {
      // Encoder is rotating CW so increment
      currentDir =":CW";
      digitalWrite(9,HIGH);
    }
  }
  // Remember last CLK state
  lastStateCLK = currentStateCLK;

  if (analogRead(A1) > 0) {
        Serial.print("A1:");
        Serial.print(analogRead(A1));
        Serial.println(currentDir);
        //Serial.println("A1:"+analogRead(A1));
    }
    /*
    if (analogRead(A2) > 0) {
      Serial.print("A2: ");
        Serial.println(analogRead(A2));
  }
  if (analogRead(A3) > 0) {
    Serial.print("A3: ");
    Serial.println(analogRead(A3));
  }
  if (analogRead(A4) > 0) {
    Serial.print("A4: ");
    Serial.println(analogRead(A4));
  }
  if (analogRead(A5) > 0) {
    Serial.print("A5: ");
    Serial.println(analogRead(A5));
  }
  */
}
