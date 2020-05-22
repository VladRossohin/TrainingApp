import { Component, OnInit, Input } from '@angular/core';
import { Kick } from '../models/kick';

@Component({
  selector: 'app-kick-chart',
  templateUrl: './kick-chart.component.html',
  styleUrls: ['./kick-chart.component.css']
})
export class KickChartComponent implements OnInit {

  @Input() kicks: Kick[];

  public chartOptions = {
    
  };

  public chartLabels: Array<number>;
  public chartData = {
    data: [],
    label: 'Reaction speed'
  }

  public chartType = 'line';
  public chartLegend = true;

  constructor() {
    this.kicks.forEach(k => {
      this.chartLabels.push(k.kickDateTime.getTime());
      this.chartData.data.push(k.reactionSpeed);
    })
   }



  ngOnInit(): void {
  }

}
