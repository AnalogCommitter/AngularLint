import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { ReceiptService } from '../services/receipt.service';

@Component({
  selector: 'app-tip',
  templateUrl: './tip.component.html',
  styleUrls: ['./tip.component.css']
})
export class TipComponent implements OnInit {
  data: number[][] = []
  item: number[] = []
  boolItem: boolean[] = []
  count = 0
  toggle: boolean[][] = []
  jokerCheck!: boolean;
  tip: number[] = []
  sendClicked = false
  timestamp = null

  constructor(public recService: ReceiptService, public router: Router, public httpClient: HttpClient) { }

  fillArray() {     
    for (var j = 1; j < 11; j++)
    {
      this.data.push(this.item);
      this.toggle.push(this.boolItem)
      this.item = []
      this.boolItem = []

      for (var u = 1; u < 6; u++)
      {      
        this.count++;
        this.item.push(this.count);   
        this.boolItem.push(false)
      }
    }
  }

  colorSquare(y: number, x: number) {
    var index = 0;
    if(this.toggle[x][y])
    {
      this.toggle[x][y] = false
      
      for(const o of this.tip)
      {
        if(o == this.data[x][y])
        {
          this.tip.splice(index,1)
        }
        index++
      }
    } else {
      this.toggle[x][y] = true
      this.tip.push(this.data[x][y])
    }
  }

  async sendTip() {
      const rawResponse = await fetch('https://localhost:5001/api/tip', {
    method: 'POST',
    headers: {
      'Accept': 'application/json',
      'Content-Type': 'application/json'
    },
      body: JSON.stringify({numbers: this.tip, joker: this.jokerCheck})
    });
    const content = await rawResponse.json();

    console.log(content);

    this.sendClicked = true
    this.recService.receiptNumber = content.receiptNumber
    this.timestamp = content.receiptTimestamp
  }

  ngOnInit(): void {
    this.fillArray()
  }
}
