<template>
  <v-layout align-start>
    <v-flex>
      <v-toolbar flat color="white">
        <v-toolbar-title>Comprobantes</v-toolbar-title>
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
        <v-btn color="success" @click="exportToExcel"> Excel<span class="iconify" data-icon="mdi-file-excel" ></span></v-btn>
      </v-toolbar>
      <v-data-table :headers="headers" :items="comprobantes" :search="search" class="elevation-1">
        <template slot="items" slot-scope="props">
          <td class="justify-center layout px-0">
            <v-icon small class="mr-2" @click="eliminar(props.item.id)">delete</v-icon>
          </td>
          <td class="excelTD" id="HoraInicio" >{{ props.item.horaInicio }}</td>
          <td class="excelTD" id="HoraFin" >{{ props.item.horaFin }}</td>
          <td class="excelTD" id="Parking" >{{ props.item.parking }}</td>
          <td class="excelTD" id="Espacio" >{{ props.item.espacio }}</td>
          <td class="excelTD" id="Monto" >S/.{{ props.item.monto }}</td>
        </template>
        <template slot="no-data">
          <v-btn color="primary" @click="listar">Resetear</v-btn>
        </template>
      </v-data-table>
    </v-flex>
  </v-layout>

</template>
<script>
import axios from "axios";
import XLSX from "xlsx"
export default {
  data() {
    return {
      comprobantes: [],
      dialog: false,
      headers: [
        { text: "Opciones", value: "opciones", sortable: false },
        { text: "Hora Inicio", value: "horaInicio", sortable: false },
        { text: "Hora Salida", value: "horaFin", sortable: false },
        { text: "Parking", value: "parking", sortable: false },
        { text: "Espacio", value: "espacio", sortable: false },
        { text: "Monto facturado", value: "monto", sortable: false },
      ],
      search: "",

      //Model
      id: "",
      horaFin: "",
      monto: ""
    };
  },
  computed: {

  },

  watch: {
    dialog(val) {
      val || this.close();
    }
  },

  created() {
    this.listar();
    this.loadAdministradores();
  },
  methods: {
    listar() {
      let me = this;
      axios
        .get("api/comprobantes/View")
        .then(function(response) {
          //console.log(response);
          me.comprobantes = response.data;
        })
        .catch(function(error) {
          console.log(error);
        });
    },

    eliminar(index) {
        if (confirm('¿Estas seguro de eliminar este comprobante?')){
           let me = this;
      axios
        .delete("api/comprobantes/"+index
        )
        .then(function(response) {
          me.listar()
       })
        .catch(function(error) {
            alert("Hubo un error al eliminar el comprobante")
        });}
    },

    close() {
      this.dialog = false;
    },
    exportToExcel(){
        let wb = XLSX.utils.book_new();
        wb.SheetNames.push("Comprobantes")
        var ws_data= this.tableToJson("excelTD")
        let ws=XLSX.utils.json_to_sheet(ws_data)
        wb.Sheets["Comprobantes"]=ws
        var wscols = [
                {wch:20},
                {wch:20},
                {wch:20},
                {wch:20}
            ];

        wb['!cols'] = wscols; 
        XLSX.writeFile(wb, 'Comprobantes.xlsx');
       
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
    limpiar() {
      this.id = "";
      this.nombre_Estacionamiento= "";
      this.direccion= "";
      this.descripcion= "";
      this.pais= "";
      this.telefono= 0;
      this.localizacion= "";
      this.numero_Espacios= 0;
      this.administradorId= "";
    },

    nuevoObj() {
      this.id = "";
      this.nombre_Estacionamiento= "";
      this.direccion= "";
      this.descripcion= "";
      this.pais= "";
      this.telefono= 0;
      this.localizacion= "";
      this.numero_Espacios= 0;
      this.administradorId= "";
    },

  }
};
</script>