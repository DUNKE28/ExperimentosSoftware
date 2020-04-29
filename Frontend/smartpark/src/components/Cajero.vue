<template>
  <v-layout align-start>
    <v-flex>
      <!--<v-alert v-model="alert" dismissible type="success">Se ha actualizado correctamente</v-alert>-->
      <!--<v-alert v-model="error" dismissible type="error">No se pudo actualizado correctamente</v-alert>-->
      <v-toolbar flat color="white">
        <v-toolbar-title>Cajeros</v-toolbar-title>
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
        <v-dialog v-model="dialog" max-width="500px">
          <v-btn slot="activator" color="primary" dark class="mb-2">Nuevo</v-btn>
          <v-card>
            <v-card-title>
              <span class="headline">{{ formTitle }}</span>
            </v-card-title>

            <v-card-text>
              <v-container grid-list-md>
                <v-layout wrap>
                  <v-flex xs12 sm12 md12>
                    <v-text-field v-model="username" label="Username"></v-text-field>
                  </v-flex>
                  <v-flex xs12 sm12 md12>
                    <v-text-field v-model="nombre_Cajero" label="Nombre"></v-text-field>
                  </v-flex>
                  <v-flex xs12 sm12 md12>
                    <v-text-field v-model="apellido_Cajero" label="Apellido"></v-text-field>
                  </v-flex>
                  <v-flex xs12 sm12 md12>
                    <v-text-field v-model="contraseña" label="Contraseña"></v-text-field>
                  </v-flex>
                  <v-flex xs12 sm12 md12>
                    <v-select v-model="turno_Cajero" :items="metodosCajero" label="Turno">
                    </v-select>
                  </v-flex>
                </v-layout>
              </v-container>
            </v-card-text>

            <v-card-actions>
              <v-spacer></v-spacer>
              <v-btn color="blue darken-1" flat @click.native="close">Cancelar</v-btn>
              <v-btn color="blue darken-1" flat @click.native="guardar">Guardar</v-btn>
            </v-card-actions>
          </v-card>
        </v-dialog>
      </v-toolbar>
      <v-data-table :headers="headers" :items="cajeros" :search="search" class="elevation-1">
        <template slot="items" slot-scope="props">
          <td class="justify-center layout px-0">
            <v-icon small class="mr-2" @click="editItem(props.item)">edit</v-icon>
            <v-icon small class="mr-2" @click="deletea(props.item.id)">delete</v-icon>
          
          </td>
          <td>{{ props.item.username }}</td>
          <td>{{ props.item.nombre_Cajero }}</td>
          <td>{{ props.item.apellido_Cajero }}</td>
          <td>{{ props.item.contraseña}}</td>
          <td>{{ props.item.fecha_ingreso }}</td>
          <td>{{ props.item.turno_Cajero }}</td>
          
         
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
export default {
  data() {
    return {
      cajeros: [],
      dialog: false,
      headers: [
        { text: "Opciones", value: "opciones", sortable: false },
        { text: "User Name", value: "username", sortable: false },
        { text: "Nombre", value: "nombre_Cajero", sortable: false },
        { text: "Apellido", value: "apellido_Cajero", sortable: false },
        { text: "Contraseña", value: "contraseña", sortable: false },
        { text: "FechaIngreso", value: "fecha_ingreso" },
        { text: "TurnoCajero", value: "turno_Cajero" },
      ],
      search: "",
      editedIndex: -1,

      puntos: [],

      //Model
      id:'',
      username: '',
      nombre_Cajero: '',
      apellido_Cajero: '',
      contraseña: '',
      fecha_ingreso: '',
      turno_Cajero: '',
      metodosCajero: ['Mañana', 'Tarde', 'Noche'],

    };
  },
  computed: {
    formTitle() {
      return this.editedIndex === -1 ? "Nuevo Cajero" : "Actualizar Cajero";
    }
  },

  watch: {
    dialog(val) {
      val || this.close();
    }
  },

  created() {
    this.listar();
    
  },
  methods: {
    listar() {
      let me = this;
      axios
        .get("api/cajeros")
        .then(function(response) {
          //console.log(response);
          me.cajeros = response.data;
        })
        .catch(function(error) {
          console.log(error);
        });
    },

    timeI(item){
      var fecha=new Date(item.fechaIngreso);
      return fecha.getFullYear()+"-"+fecha.getMonth()+"-"+fecha.getDate()+" "+fecha.getHours()+":"
      +fecha.getMinutes();
    },

     editItem(item) {
       this.id = item.id;
       this.username = item.username,
       this.nombre_Cajero = item.nombre_Cajero;
       this.apellido_Cajero = item.apellido_Cajero;
       this.contraseña = item.contraseña;
       //this.fecha_ingreso = item.fecha_ingreso;
       this.turno_Cajero = item.turno_Cajero;
      

       this.editedIndex = 1;
       this.dialog = true;
     },

    //  deleteItem(item){
    //    this.id=item.id;
    // },

    close() {
      this.dialog = false;
    },
    limpiar() {
      this.id = "";
      this.username = "";
      this.nombre_Cajero = "";
      this.apellido_Cajero = "";
      this.contraseña = "";
     // this.fecha_ingreso = "";
      this.turno_Cajero = "";
     
    },
    guardar() {
      if (this.editedIndex > -1) {
        //Código para editar

         let me = this;
         axios 
           .put("api/cajeros", {
            id: me.id,
            username: me.username,
            nombre_Cajero: me.nombre_Cajero,
            apellido_Cajero: me.apellido_Cajero,
            contraseña: me.contraseña,
           // fecha_ingreso: me.fecha_ingreso,
            turno_Cajero: me.turno_Cajero,
            
           })
           .then(function(response) {
             me.close();
             me.listar();
             me.limpiar();
             //me.alert=true;
           })
           .catch(function(error) {
             console.log(error);
             //me.error=true;
           });
      } else {
        //Código para guardar
        let me = this;
        axios
          .post("api/cajeros", {
            username: me.username,
            nombre_Cajero: me.nombre_Cajero,
            apellido_Cajero: me.apellido_Cajero,
            contraseña:me.contraseña,
            fecha_ingreso: new Date(),
            turno_Cajero: me.turno_Cajero,
            
          })
          .then(function(response) {
            me.close();
            me.listar();
            me.limpiar();
            //me.alert=true;
          })
          .catch(function(error) {
            console.log(error);
            //me.error=true;
          });
      }
    },
    deletea(index){
        if (confirm('¿Estas seguro de eliminar este cajero?')){
           let me = this;
      axios
        .delete("api/cajeros/"+index
        )
        .then(function(response) {
          me.listar()
       })
        .catch(function(error) {
            alert("Hubo un error al eliminar un cajero")
        });}

      },
  }
};
</script> 