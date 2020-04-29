<template>
  <v-layout align-start>
    <v-flex>
      <!--<v-alert v-model="alert" dismissible type="success">Se ha actualizado correctamente</v-alert>-->
      <!--<v-alert v-model="error" dismissible type="error">No se pudo actualizado correctamente</v-alert>-->
      <v-toolbar flat color="white">
        <v-toolbar-title>Administradores</v-toolbar-title>
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
                    <v-text-field v-model="nombre_adm" label="Nombre"></v-text-field>
                  </v-flex>
                  <v-flex xs12 sm12 md12>
                    <v-text-field v-model="apellido_adm" label="Apellido"></v-text-field>
                  </v-flex>
                  <v-flex xs12 sm12 md12>
                    <v-text-field v-model="contraseña"  label="Contraseña"></v-text-field>
                    
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
      <v-data-table :headers="headers" :items="administradores" :search="search" class="elevation-1">
        <template slot="items" slot-scope="props">
          <td class="justify-center layout px-0">
            <v-icon small class="mr-2" @click="editItem(props.item)">edit</v-icon>
            <v-icon small class="mr-2" @click="deletea(props.item.id)">delete</v-icon>
          
          </td>
          <td>{{ props.item.username}}</td>
          <td>{{ props.item.nombre_adm}}</td>
          <td>{{ props.item.apellido_adm }}</td>
          <td>{{ props.item.contraseña }}</td>
         
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
      administradores: [],
      dialog: false,
      headers: [
        { text: "Opciones", value: "opciones", sortable: false },
        { text: "User Name", value: "username", sortable: false },
        { text: "Nombre", value: "nombre_adm", sortable: false },
        { text: "Apellido", value: "apellido_adm", sortable: false },
        { text: "Contraseña", value: "contraseña",sortable: false  }
      ],
      search: "",
      editedIndex: -1,

      puntos: [],

      //Model
      id:'',
      username:'',
      nombre_adm: '',
      apellido_adm: '',
      contraseña: ''
    };
  },
  computed: {
    formTitle() {
      return this.editedIndex === -1 ? "Nuevo Administrador" : "Actualizar Administrador";
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
        .get("api/administradores")
        .then(function(response) {
          //console.log(response);
          me.administradores = response.data;
        })
        .catch(function(error) {
          console.log(error);
        });
    },

    
    
     editItem(item) {
       this.id = item.id;
       this.username = item.username;
       this.nombre_adm = item.nombre_adm;
       this.apellido_adm = item.apellido_adm;
       this.contraseña = item.contraseña;
       

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
      this.nombre_adm = "";
      this.apellido_adm = "";
      this.contraseña = "";
     
    },
    guardar() {
      if (this.editedIndex > -1) {
        //Código para editar

         let me = this;
         axios 
           .put("api/administradores", {
            id: me.id,
            username: me.username,
            nombre_adm: me.nombre_adm,
            apellido_adm: me.apellido_adm,
            contraseña: me.contraseña
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
          .post("api/administradores", {
            username: me.username,
            nombre_adm: me.nombre_adm,
            apellido_adm: me.apellido_adm,
            contraseña: me.contraseña
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
        if (confirm('¿Estas seguro de eliminar este administrador?')){
           let me = this;
      axios
        .delete("api/administradores/"+index
        )
        .then(function(response) {
          me.listar()
       })
        .catch(function(error) {
            alert("Hubo un error al eliminar un administrador")
        });}

      },
  }
};
</script> 