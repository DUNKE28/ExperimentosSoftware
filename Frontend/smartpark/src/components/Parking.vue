<template>
  <v-layout align-start>
    <v-flex>
      <v-toolbar flat color="white">
        <v-toolbar-title>Parkings</v-toolbar-title>
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
          <v-btn slot="activator" color="primary" dark class="mb-2" @click.native="nuevoObj">Nuevo</v-btn>
          <v-card>
            <v-card-title>
              <span class="headline">{{ formTitle }}</span>
            </v-card-title>

            <v-card-text>
              <v-container grid-list-md>
                <v-layout wrap>
                  <v-flex xs12 sm12 md12>
                    <v-text-field :rules="[ v => !!v || 'Nombre es requerido']" v-model="nombre_Estacionamiento" label="Nombre"></v-text-field>
                    <v-text-field :rules="[ v => !!v || 'Direccion es requerido']" v-model="direccion" label="Direccion"></v-text-field>
                    <v-text-field  :rules="[ v => !!v || 'Descripcion es requerido']" v-model="descripcion" label="Descripcion"></v-text-field>
                    <v-text-field  :rules="[ v => !!v || 'Pais es requerido']" v-model="pais" label="Pais"></v-text-field>
                    <v-text-field  :rules="[ v => !!v || 'Telefono es requerido',v => (v && v.length == 9) || 'Telefono debe tener 9 caracteres']" v-model="telefono" label="Telefono"></v-text-field>
                    <v-text-field  :rules="[ v => !!v || 'Localizacion es requerido']" v-model="localizacion" label="Localizacion"></v-text-field>
                    <v-text-field  :rules="[ v => !!v || 'Cantidad de espacios es requerido']" v-model="numero_Espacios" label="Cantidad espacios"></v-text-field>
                  </v-flex>
                </v-layout>
              </v-container>
            </v-card-text>

            <v-card-actions>
              <v-spacer></v-spacer>
              <v-btn color="blue darken-1" flat @click.native="close">Cancelar</v-btn>
              <v-btn color="blue darken-1" flat @click.native="guardarVeri">Guardar</v-btn>
            </v-card-actions>
          </v-card>
        </v-dialog>
      </v-toolbar>
      <v-data-table :headers="headers" :items="parkings" :search="search" class="elevation-1">
        <template slot="items" slot-scope="props">
          <td class="justify-center layout px-0">
            <v-icon small class="mr-2" @click="eliminar(parkings,props.item)">delete</v-icon>
            <v-icon small class="mr-2" @click="editItem(props.item)">edit</v-icon>
          </td>
          <td>{{ props.item.nombre_estacionamiento }}</td>
          <td>{{ props.item.direccion }}</td>
          <td>{{ props.item.descripcion }}</td>
          <td>{{ props.item.pais }}</td>
          <td>{{ props.item.telefono }}</td>
          <td>{{ props.item.localizacion }}</td>
          <td>{{ props.item.numero_Espacios }}</td>
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
      parkings: [],
      administradores: [],
      dialog: false,
      headers: [
        { text: "Opciones", value: "opciones", sortable: false },
        { text: "Nombre", value: "nombre_estacionamiento", sortable: false },
        { text: "Direccion", value: "direccion", sortable: false },
        { text: "Descripcion", value: "descripcion" },
        { text: "Pais", value: "pais" },
        { text: "Telefono", value: "telefono" },
        { text: "Localizacion", value: "localizacion" },
        { text: "Cantidad espacios", value: "numero_Espacios" }
      ],
      search: "",
      editedIndex: -1,

      //Model
      id: "",
      nombre_Estacionamiento: "",
      direccion: "", 
      descripcion: "",
      pais: "",
      telefono: 0,
      localizacion: "",
      numero_Espacios: 0,
      administradorSelect: localStorage.getItem('id')
    };
  },
  computed: {
    formTitle() {
      return this.editedIndex === -1 ? "Nuevo Parking" : "Actualizar Parking";
    }
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
        .get("api/parkings")
        .then(function(response) {
          //console.log(response);
          me.parkings = response.data;
        })
        .catch(function(error) {
          console.log(error);
        });
    },

    loadAdministradores(){
      let me =this;
      var aux=[];
        axios.get("api/administradores").then(function(response){
         console.log(response);
          aux=response.data;
          aux.map((t)=>{
            me.administradores.push(
              {
                text:t.nombre_adm,
                value:t.id
              }
            )
          });
      }).catch(function(error){
        console.log(error);
      })
    },

    eliminar(arr, item) {
        var i = arr.indexOf(item);
        if (i !== -1) {
            arr.splice(i, 1);
        }
    },

    editItem(item) {
      this.id = item.id;
      this.nombre_Estacionamiento=item.nombre_Estacionamiento;
      this.direccion=item.direccion;
      this.descripcion=item.descripcion;
      this.pais=item.pais;
      this.telefono=item.telefono;
      this.localizacion=item.localizacion;
      this.numero_Espacios=item.numero_Espacios;
      this.administradorId=item.administradorId;
  
      this.editedIndex = 1;
      this.dialog = true;
    },

    close() {
      this.dialog = false;
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
      this.editedIndex = -1;
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

    guardar() {
      if (this.editedIndex > -1) {
        //Código para editar

        let me = this;
        axios 
          .put("api/parkings", {
            id: me.id,
            nombre_estacionamiento: me.nombre_Estacionamiento,
            direccion: me.direccion,
            descripcion: me.descripcion,
            pais:me.pais,
            telefono:me.telefono,
            localizacion:me.localizacion,
            numero_Espacios:me.numero_Espacios,
            administradorId:me.administradorSelect
    
          })
          .then(function(response) {
            me.close();
            me.listar();
            me.limpiar();
          })
          .catch(function(error) {
            console.log(error);
          });
      } else {
        //Código para guardar
        let me = this;
        axios
          .post("api/parkings", {
            nombre_estacionamiento: me.nombre_Estacionamiento,
            direccion: me.direccion,
            descripcion: me.descripcion,
            pais:me.pais,
            telefono:me.telefono,
            localizacion:me.localizacion,
            numero_Espacios:me.numero_Espacios,
            administradorId:me.administradorSelect
          })
          .then(function(response) {
            me.close();
            me.listar();
            me.limpiar();
          })
          .catch(function(error) {
            console.log(error);
          });
      }
    },
    guardarVeri(){
            if (this.nombre_estacionamiento != '' && this.direccion != '' && this.descripcion != '' && this.pais != '' 
            && (this.telefono > 99999999 && this.telefono < 1000000000) && this.localizacion != '' && this.numero_Espacios != 0){
                this.guardar()
            }else {
                alert('FALLO: verifique los campos.')
            }
        },
  }
};
</script>
