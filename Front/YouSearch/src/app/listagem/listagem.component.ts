import { Component, OnInit } from '@angular/core';
import { Dados } from './Procura';
import { ActivatedRoute } from '@angular/router';
import { ListagemService } from './listagem.service';

@Component({
  selector: 'app-listagem',
  templateUrl: './listagem.component.html',
  styleUrls: ['./listagem.component.css']
})
export class ListagemComponent implements OnInit {

  listaDados: Dados[] = [];
  filtro:string = "";
  temMais: boolean = false;
  ProximaPagina: string = "";
  


  constructor(private activatedRoute: ActivatedRoute,
    private servico: ListagemService) { }


  ngOnInit(): void {
   
  }

  onKey(event: any) {
    this.filtro = event.target.value;
  }

  filtrar(){
    this.servico.buscar(this.filtro).subscribe(result => {
      result.dados.forEach(valor => this.listaDados.push(valor));
      this.temMaisDados(result.proximaPagina);
    });

    
  }

  load(){
    this.servico.buscar(this.filtro, this.ProximaPagina).subscribe(result => {
      result.dados.forEach(valor => this.listaDados.push(valor));
      this.temMaisDados(result.proximaPagina);
    });
  }


  temMaisDados(pagina: string){
    if(pagina){
      this.temMais = true;
      this.ProximaPagina = pagina;
    }else{
      this.temMais = false;
      this.ProximaPagina = "";
    }
  }
}
