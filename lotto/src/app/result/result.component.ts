import { Component, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { ReceiptService } from '../services/receipt.service';
import { TipComponent } from '../tip/tip.component';

@Component({
  selector: 'app-result',
  templateUrl: './result.component.html',
  styleUrls: ['./result.component.css'],
  providers: [
    TipComponent
  ]
})
export class ResultComponent implements OnInit {
  correctNumbers = 0
  extraNumber = false
  result = ''
  sendClicked = false

  constructor(public recService: ReceiptService, public router: Router, private tipComponent: TipComponent) { 
    
  }

  async receiveResults () {
    const response = await fetch('https://localhost:5001/api/tip?receiptNumber=' + this.recService.receiptNumber);
    const resultList = await response.json();

    console.log(resultList)

    this.correctNumbers = resultList.correctNumbers
    this.extraNumber = resultList.zusatzzahl
    this.determineResult()
    this.sendClicked = true
  }

  determineResult () 
  {
    switch(this.correctNumbers) { 
      case 0: { 
        this.result='Sie haben leider keine richtigen Zahlen und daher nichts gewonnen'
         break; 
      } 
      case 1: { 
        this.result='Sie haben nur eine richtige Zahl und daher nichts gewonnen'
         break; 
      } 
      case 2: { 
        this.result='Sie haben nur zwei richtige Zahlen und daher nichts gewonnen'
        break; 
      } 
      case 3: { 
        this.result='Gratuliere, Sie haben einen Dreier'
        break; 
      } 
      case 4: { 
        this.result='Gratuliere, Sie haben einen Vierer'
        break; 
      } 
      case 5: { 
        if(this.extraNumber)
        {
          this.result='Gratuliere, Sie haben einen Fünfer mit Zusatzzahl'
        } else {
          this.result='Gratuliere, Sie haben einen Fünfer'
        }
        break; 
      } 
      case 6: { 
        this.result='Jackpot!'
        break; 
      }
      default: { 
        this.result='Etwas stimmt mit der Belegnummer nicht!'
      } 
   } 
  }

  ngOnInit(): void {
  }
}
