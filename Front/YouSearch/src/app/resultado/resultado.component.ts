import { Component, OnInit, Input, OnChanges, SimpleChanges } from '@angular/core';
import { Dados } from '../listagem/Procura';

@Component({
  selector: 'app-resultado',
  templateUrl: './resultado.component.html',
  styleUrls: ['./resultado.component.css']
})
export class ResultadoComponent implements OnInit {

  @Input() listaDados: any[] = [];

  constructor() { }

  ngOnInit(): void {
  }

}
