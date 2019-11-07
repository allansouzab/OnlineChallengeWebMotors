import { Component, OnInit } from '@angular/core';
import { WebMotorsService } from '../services/web-motors/web-motors.service';
import { Marca } from '../core/marca';
import { Modelo } from '../core/modelo';
import { Versao } from '../core/versao';
import { MatTableDataSource } from '@angular/material/table';
import { VeiculosService } from '../services/veiculos/veiculos.service';
import { Carro } from '../core/carro';

@Component({
  selector: 'app-veiculos',
  templateUrl: './veiculos.component.html',
  styleUrls: ['./veiculos.component.css']
})
export class VeiculosComponent implements OnInit {

  displayedColumns: string[] = ['Marca', 'Modelo', 'Versao', 'Ano', 'Quilometragem', 'Observacao', 'btn-primary', 'btn-danger'];
  dataSource: MatTableDataSource<Carro>;

  marcas = new Array<Marca>();
  modelos = new Array<Modelo>();
  versoes = new Array<Versao>();

  selectedCarro = new Carro();
  selectedMarca: number;
  selectedModelo: number;
  selectedVersao: number;

  retorno: any;

  constructor(private webmotorsService: WebMotorsService, private veiculosService: VeiculosService) { }

  ngOnInit() {
    this.getAllMarcas();
    this.getCarros();
  }

  getAllMarcas(){
    this.webmotorsService.getAllMarcas().subscribe(data => {
      this.marcas = null;
      this.marcas = data;
    });
  }

  getModelosByMarca(){
    this.webmotorsService.getModelosByMarca(this.selectedMarca.toString()).subscribe(data => {
      this.modelos = null;
      this.modelos = data;
    });
  }

  getVersoesByModelo(){
    this.webmotorsService.getVersoesByModelo(this.selectedModelo.toString()).subscribe(data => {
      this.versoes = null;
      this.versoes = data;
    });
  }

  AddCarro(){
    debugger
    let marca = this.selectedMarca;
    let modelo = this.selectedModelo;
    let versao = this.selectedVersao;

    this.selectedCarro.Marca = this.marcas.find(function (element){
      return element.ID == marca;
    }).Name;

    this.selectedCarro.Modelo = this.modelos.find(function (element){
      return element.ID == modelo;
    }).Name;

    this.selectedCarro.Versao = this.versoes.find(function (element){
      return element.ID == versao;
    }).Name;

    this.selectedCarro.Ano = 2010;
    this.selectedCarro.Quilometragem = 1000;
    this.selectedCarro.Observacao = 'Sem avarias';

    this.veiculosService.addVeiculo(this.selectedCarro).subscribe(data => {
      debugger
      this.retorno = data;
      this.getCarros();
    });
  }

  getCarros(){
    this.veiculosService.ObterVeiculos().subscribe(data => {
      this.dataSource = data;
    });
  }

  deleteCarro(id: number){
    debugger
    this.veiculosService.removerVeiculo(id).subscribe(data => {
      debugger
      this.retorno = data;
      this.getCarros();
    });
  }

  changeCarro(carro: Carro){
    debugger
    this.veiculosService.alterarVeiculo(carro).subscribe(data => {
      debugger
      this.retorno = data;
      this.getCarros();
    });
  }

}
