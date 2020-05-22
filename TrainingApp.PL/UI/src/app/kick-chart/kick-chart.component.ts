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

  public chartLabels: string[] = [];
  public chartData = [
    {
      data: [],
      label: 'Reaction speed',
      fill: false,
      trendlineLinear: {
        style: "rgba(255,105,180, .8)",
		    lineStyle: "dotted|solid",
		    width: 2
      }
    }
  ];
  

  public chartType = 'line';
  public chartLegend = true;

  constructor() {
    
   }

  ngOnInit(): void {
    this.initData();
  }

  initData() {
     this.kicks.forEach((k) => {
       this.chartLabels.push(k.kickDateTime.toString());
       this.chartData[0].data.push(k.reactionSpeed);
    });
  }
}
