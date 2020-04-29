<template>
  <v-layout align-start>
      <v-flex>
            <v-toolbar flat color="white">
                <v-toolbar-title>Ingresos</v-toolbar-title>
                <v-divider class="mx-2" inset vertical></v-divider>
                <v-spacer></v-spacer>
                <v-text-field
                    class="text-xs-center"
                    v-model="search"
                    append-icon="search"
                    label="Búsqueda"
                    single-line
                    hide-details
                    ></v-text-field>
                <v-spacer></v-spacer>
                <v-select class="select-paginator"
                  xs
                  :items="optionsPaginator"
                  v-model="rowsPerPage"
                  label="Nro Entradas"
                ></v-select>
                <v-btn color="success" @click="exportToExcel"> Excel<span class="iconify" data-icon="mdi-file-excel" ></span></v-btn>


                <v-dialog persistent v-model="dialog" max-width="500px">
                  <v-btn slot="activator" color="primary" dark class="mb-2" >Nuevo</v-btn>
                    <v-card>
                      <v-card-title>
                        <span class="headline">{{ formTitle }}</span>
                      </v-card-title>
                      <v-form
                        ref="formNuevo"
                        
                        lazy-validation
                      
                      >
                        <v-card-text>
                          <v-container grid-list-md>
                            <v-layout wrap>
                              <v-flex xs12 sm12 md12>
                                <v-select required :items="tarifas" v-model="tarifa" item-text="name" item-value="id" label="Tarifa" ></v-select>
                                <v-text-field  :counter="7" :rules="[ v => !!v || 'Placa es requerida',v => (v && v.length ==7) || 'Placa debe tener 7 caracteres']" v-model="placa" label="Placa"></v-text-field>
                                <v-text-field  :rules="[ v => !!v ]" v-model="espacio.identificador" label="Espacio" >
                                  <template v-slot:append>
                                    <v-icon color="blue darken-2" @click.passive="loadEspacios" @click.stop="dialogIngresos=true"> add_circle</v-icon> 
                                    <v-dialog lazy persistent v-model="dialogIngresos" max-width="500px" scrollable>
                                      <v-card  >
                                        <v-card-title>
                                          <span class="headline">Espacios </span>
                                        </v-card-title>
                                      <v-item-group  >
                                        <v-container grid-list-sm >
                                          <v-layout id="gridEspacios" wrap style="height: 300px;  overflow-y:auto"  >
                                            <v-flex v-for="n in espacios" :key="n.id"  >
                                              <v-item v-if="n.disponibilidad_espacio">
                                                <v-card
                                                  slot-scope="{ active, toggle }"
                                                  :color="active ? 'primary' : 'secondary'"
                                                  class="d-flex align-center"
                                                  dark
                                                  width=100
                                                  height=100
                                                  @click="toggle"
                                                  @click.passive="closeItemsDialog(n)"
                                                >
                                                  
                                                      <v-card-title primary-title >
                                                       
                                                             <div class=".display-1" >{{n.identificador}}</div>
                                                        
                                                      </v-card-title>
                                                    
                                                 
                                                </v-card>
                                              </v-item>
                                            </v-flex>
                                          </v-layout>
                                        </v-container>
                                      </v-item-group>
                                       </v-card>
                                    </v-dialog>
                                  </template>


                                </v-text-field>
                              </v-flex>
                            </v-layout>
                          </v-container>
                        </v-card-text>
                     
                      <v-card-actions>
                        <v-spacer></v-spacer>
                        <v-btn color="blue darken-1" flat @click.native="close">Cancelar</v-btn>
                        <v-btn color="blue darken-1" flat @click.native="save">Guardar</v-btn>
                      </v-card-actions>
                     </v-form>
                    </v-card>
                </v-dialog>
            </v-toolbar>
            <v-data-table 
            :headers="headers"
            :items="ingresos"
            class="elevation-1"
            hide-actions
            :pagination.sync="pagination"
            :search="search"
            >
                <template v-slot:items="props">
                    <td class="excelTD" id="Placa" >{{ props.item.placa }}</td>
                    <td class="excelTD"  id="Espacio" >{{ props.item.espacio }}</td>
                    <td class="excelTD" id="Fecha" >{{ parseDateTime( props.item.hInicio) }}</td>
                    <td class="excelTD" id="Cajero">{{ props.item.nombreCajero }}</td>
                    <td class>
                    <v-icon
                        small
                        class="mr-2"
                        @click="editItem(props.item.id)"
                    >
                        edit
                    </v-icon>
                    <v-icon
                        small
                        @click="deleteIngreso(props.item.id)"
                    >
                        delete
                    </v-icon>
                    <v-icon
                        small
                        @click="loadIngreso(props.item.id,props.item)"
                    >
                        receipt
                    </v-icon>
                    </td>
                </template>
                <template v-slot:no-data>
                    <v-alert :value="true" color="error" icon="warning">
                            No hay ingresos disponibles
                          </v-alert>
                </template>
            </v-data-table>
            <div class="text-xs-center pt-2">
              <v-pagination v-model="pagination.page" :length="pages"></v-pagination>
            </div>  
            
             
        </v-flex>
  </v-layout>
  </template>
  <script>
  import axios from "axios";
  import XLSX from "xlsx"
  import Cajero from "../models/cajero"
  import Espacio from "../models/espacio"
  import Ingreso from "../models/ingreso"
  import Tarifa from "../models/tarifa"
  export default {
    data: () => ({
      dialog: false,
      rowsPerPage:"5",
      optionsPaginator:["5","10","15"],
      espacio:"",
      placa:"",
      tarifa:"",
      cajero: localStorage.getItem('id'),
      parking: localStorage.getItem('parking'),
      pagination: {},
      dialogIngresos:false,
      search: "",
      ingresos:[],
      cajeroaux: '',
      espacioaux: '',
      espacios:[],
      headers: [
        { text: 'Placa', value: 'placa' },
        { text: 'Espacio', value: 'espacio' },
        { text: 'Inicio', value: 'inicio' },
        { text: 'Cajero', value: 'cajero' },
        { text: 'Options', value: 'options' }
      ],
      desserts: [],
      editedIndex: -1,
      editedItem: {
        name: '',
        calories: 0,
        fat: 0,
        carbs: 0,
        protein: 0
      },
      viewModel: {
        name: '',
        calories: 0,
        fat: 0,
        carbs: 0,
        protein: 0
      },
      tarifas:[],
      cajeros:[]
    }),

    computed: {
      formTitle () {
        return this.editedIndex === -1 ? 'Nuevo Ingreso' : 'Editar Ingreso'
      },
      pages () {
        if (this.pagination.rowsPerPage == null ||
          this.pagination.totalItems == null
        ) return 0
        // this.pagination.rowsPerPage/2
        
        return Math.ceil(this.ingresos.length/this.rowsPerPage)
      }
    },

    watch: {
      dialog (val) {
        val || this.close()
        this.$refs.formNuevo.reset()
      }
    },

    created () {
      this.initialize()
    },

    methods: {
      limpiar(){
        let me =this;
        me.espacio="";
        me.placa="";
        me.tarifa="";
      },
      loadEspacios(){
          let me = this;
      axios
        .get("api/espacios/park/"+me.parking)
        .then(function(response) {
          
          response.data.forEach(function (espacio) {
            me.espacios.push(espacio);
          })
          
       })
        .catch(function(error) {
          console.log(error);
        });
      },
      loadCajeros(){
          let me = this;
      axios
        .get("api/cajeros")
        .then(function(response) {
          //console.log(response.data);
          response.data.forEach(function (params) {
            me.cajeros.push({
            id: params.id,
            name: params.nombre_Cajero
          });
          })
          
       })
        .catch(function(error) {
          console.log(error);
        });
      },
      loadTarifas(){
        let me = this;
      axios
        .get("api/tarifas")
        .then(function(response) {
          //console.log(response.data);
          response.data.forEach(function (params) {
            me.tarifas.push({
            "id": params.id,
            "name": params.tipo_vehiculo
          });
          })
       })
        .catch(function(error) {
          console.log(error);
        });
      },
      parseDateTime(datetime){
        
        let dato=new Date(datetime)
        return dato.getDate()+"/"+dato.getDay()+"/"+dato.getFullYear()+" "+dato.getHours()+":"+dato.getMinutes()+":"+dato.getSeconds()
      },
      initialize () {
        this.loadData();
        this.loadTarifas();
        this.loadCajeros();
        
      },
      loadData(){
          let me = this;
      axios
        .get("api/ingresos/parkView/"+me.parking)
        .then(function(response) {
          //console.log(response.data);
          me.ingresos = response.data;
       })
        .catch(function(error) {
          console.log(error);
        });
      },

      loadIngreso(idIngre, item){
        let me = this;
      axios
        .get("api/ingresos/getById/"+idIngre)
        .then(function(response) {
          console.log(me.cajeroaux);
          me.cajeroaux = response.data.cajeroId;
          me.espacioaux = response.data.espacioId;
          console.log(me.cajeroaux);
          me.postComprobante(item);
       })
        .catch(function(error) {
          console.log(error);
        });
      },

      editItem (item) {
        this.editedIndex = item
        this.llenarEdicion()
        this.dialog = true
      },
      llenarEdicion(){
        this.tarifa=this.ingresos[this.editedIndex].tarifaId;
        this.espacio=this.ingresos[this.editedIndex].espacioId;
        this.placa=this.ingresos[this.editedIndex].placa;
        this.cajero=this.ingresos[this.editedIndex].cajeroId;
        console.log(this.ingresos[0])
      },

      deleteItem (item) {
        const index = this.desserts.indexOf(item)
        confirm('Are you sure you want to delete this item?') && this.desserts.splice(index, 1)
      },

      close () {
        this.dialog = false
        setTimeout(() => {
          this.editedItem = Object.assign({}, this.defaultItem)
          this.editedIndex = -1
        }, 300)
      },
      putIngreso(){
         let me = this;
        axios
          .put("api/ingresos", {
            id: me.editedIndex,
            tarifaId: me.tarifa,
            cajeroId: me.cajero,
            placa: me.placa,
            hInicio:new Date().toLocaleDateString(),
            espacioId:parseInt(me.espacio)
          })
          .then(function(response) {
            me.close();
            me.loadData();
            me.limpiar();
          })
          .catch(function(error) {
           alert("Hubo un error al actualizar un ingreso")
          });

      },
      deleteIngreso(index){
        if (confirm('Estas seguro de eliminar este ingreso?')){
           let me = this;
      axios
        .delete("api/ingresos/"+index
        )
        .then(function(response) {
          console.log(response.data);
          me.loadData()
       })
        .catch(function(error) {
            alert("Hubo un error al eliminar un ingreso")
        });}

      },
      deleteIngresoxCom(index){
           let me = this;
      axios
        .delete("api/ingresos/"+index
        )
        .then(function(response) {
          console.log(response.data);
          me.loadData()
       })
        .catch(function(error) {
            alert("Hubo un error al eliminar un ingreso")
        });

      },
      postComprobante(item){
        if (confirm('¿Estas seguro de generar el comprobante?, el ingreso será eliminado.')){
          let me = this;
          console.log(me.cajeroaux)
          console.log(me.espacioaux)
          axios
            .post("api/comprobantes", {
              cod_ingreso: item.id,
              cajeroId: me.cajeroaux,
              espacioId: me.espacioaux,
              horaInicio: item.hInicio,
              horaFin: new Date(),
              monto: 0
            })
            .then(function(response) {
              me.deleteIngresoxCom(item.id)
              alert('Se registro el comprobante correctamente')
            })
            .catch(function(error) {
            alert("Hubo un error al registrar el comprobante")
            });
        }
      },

      postIngreso(){
        let me = this;
        axios
          .post("api/ingresos", {
            tarifaId: me.tarifa,
            cajeroId: me.cajero,
            hInicio: new Date(),
            placa: me.placa,
            espacioId:me.espacio.id
          })
          .then(function(response) {
            me.close();
            me.loadData();
            me.loadEspacios();
            me.limpiar();
          })
          .catch(function(error) {
           alert("Hubo un error al registrar un ingreso")
          });
      },
      save () {
        
         
         if (this.$refs.formNuevo.validate()) {
           if (this.editedIndex==-1) {
             this.postIngreso()
            
           }else{
             this.putIngreso()
           }
          
        }
      },
      exportToExcel(){
        let wb = XLSX.utils.book_new();
        wb.SheetNames.push("Ingresos")
        var ws_data= this.tableToJson("excelTD")
        let ws=XLSX.utils.json_to_sheet(ws_data)
        wb.Sheets["Ingresos"]=ws
        var wscols = [
                {wch:20},
                {wch:20},
                {wch:20},
                {wch:20}
            ];

        wb['!cols'] = wscols; 
        XLSX.writeFile(wb, 'Ingresos.xlsx');
       
        console.log("se exporto excel")
      },
      tableToJson(cellsTag){
        var json=[]
        let cells=document.getElementsByClassName(cellsTag);
       for (let row = 0; row< cells.length; row+=4) {
         var jsonRow={}
          for (let index = row; row < row+4; index++) {
            if (index>=cells.length) {
              break
            }
            jsonRow[cells[index].id]=cells[index].innerText
          }
      json.push(jsonRow)
       }
       return json
      },
      closeItemsDialog(item){
          this.dialogIngresos=false
          this.espacio=item
          this.espacios=[]
      }
      
      
    }
  }
</script>
<style>
  .iconify{
    color:green;
    font-size: 1.5em;
    
  }
  .select-paginator{
    display: inline;
    width: 1em;
  }
  #gridEspacios::-webkit-scrollbar {
    width: 12px;
}

#gridEspacios::-webkit-scrollbar-track {
    -webkit-box-shadow: inset 0 0 6px rgba(0,0,0,0.3); 
    border-radius: 10px;
}

#gridEspacios::-webkit-scrollbar-thumb {
    border-radius: 10px;
    -webkit-box-shadow: inset 0 0 6px rgba(0,0,0,0.5); 
}
</style>
