<template>
  <v-layout align-start>
    <v-flex>
      <v-toolbar flat color="white">
        <v-toolbar-title>Espacios</v-toolbar-title>
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
                    <v-text-field v-model="identificador" label="Identificador"></v-text-field>
                    <v-text-field v-model="disponibilidad_espacio" label="Disponibilidad"></v-text-field>
                    <v-text-field v-model="id_parking" label="Id del Parking"></v-text-field>
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
      <v-data-table :headers="headers" :items="espacios" :search="search" class="elevation-1">
        <template slot="items" slot-scope="props">
          <td class="justify-center layout px-0">
            <v-icon small class="mr-2" @click="editItem(props.item)">edit</v-icon>
          
          </td>
          <td>{{ props.item.identificador }}</td>
          <td>{{ props.item.disponibilidad_espacio }}</td>
          <td>{{ props.item.id_parking }}</td>
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
      espacios: [],
      dialog: false,
      headers: [
        { text: "Opciones", value: "opciones", sortable: false },
        { text: "Identificador", value: "identificador", sortable: false },
        { text: "Disponibilidad", value: "disponibilidad_espacio", sortable: false },
        { text: "Id del Estacionamiento", value: "id_parking", sortable: false }
      ],
      search: "",
      editedIndex: -1,

      //Model
      id: "",
      identificador: "",
      disponibilidad_espacio: "",
      id_parking: ""
    };
  },
  computed: {
    formTitle() {
      return this.editedIndex === -1 ? "Nuevo Espacio" : "Actualizar Espacio";
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
        .get("api/espacios")
        .then(function(response) {
          //console.log(response);
          me.espacios = response.data;
        })
        .catch(function(error) {
          console.log(error);
        });
    },



    
    editItem(item) {
      this.id = item.id;
      this.identificador = item.identificador;
      this.disponibilidad_espacio = item.disponibilidad_espacio;
      this.id_parking = item.id_parking;

      this.editedIndex = 1;
      this.dialog = true;
    },

  

    close() {
      this.dialog = false;
    },
    limpiar() {
      this.id = "";
      this.identificador = "";
      this.disponibilidad_espacio = "";
      this.id_parking = "";
    },
    guardar() {
      if (this.editedIndex > -1) {
        //Código para editar

        let me = this;
        axios 
          .put("api/espacios", {
            id: me.id,
            identificador: me.identificador,
            disponibilidad_espacio: me.disponibilidad_espacio,
            id_parking: me.id_parking
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
          .post("api/espacios", {
            identificador: me.identificador,
            disponibilidad_espacio: me.disponibilidad_espacio,
            id_parking: me.id_parking
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
    }
  }
};
</script>

