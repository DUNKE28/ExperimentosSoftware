<template>
  <v-layout align-start>
    <v-flex>
      <v-toolbar flat color="white">
        <v-toolbar-title>Servicios</v-toolbar-title>
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
                    <v-text-field v-model="tipo_servicio" label="Tipo de servicio"></v-text-field>
                    <v-text-field v-model="descripcion" label="Descripcion"></v-text-field>
                    <v-text-field v-model="costo_servicio" label="Costo del servicio"></v-text-field>
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
      <v-data-table :headers="headers" :items="servicios" :search="search" class="elevation-1">
        <template slot="items" slot-scope="props">
          <td class="justify-center layout px-0">
            <v-icon small class="mr-2" @click="editItem(props.item)">edit</v-icon>
          
          </td>
          <td>{{ props.item.tipo_servicio }}</td>
          <td>{{ props.item.descripcion }}</td>
          <td>{{ props.item.costo_servicio }}</td>
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
      servicios: [],
      dialog: false,
      headers: [
        { text: "Opciones", value: "opciones", sortable: false },
        { text: "Tipo de servicio", value: "tipo_servicio", sortable: false },
        { text: "Descripcion", value: "descripcion", sortable: false },
        { text: "Costo del servicio", value: "costo_servicio", sortable: false }
      ],
      search: "",
      editedIndex: -1,

      //Model
      id: "",
      tipo_servicio: "",
      descripcion: "",
      costo_servicio: ""
    };
  },
  computed: {
    formTitle() {
      return this.editedIndex === -1 ? "Nuevo Servicio" : "Actualizar Servicio";
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
        .get("api/servicios")
        .then(function(response) {
          console.log(response);
          me.servicios = response.data;
        })
        .catch(function(error) {
          console.log(error);
        });
    },
    
    editItem(item) {
      this.id = item.id;
      this.tipo_servicio = item.tipo_servicio;
      this.descripcion = item.descripcion;
      this.costo_servicio = item.costo_servicio;

      this.editedIndex = 1;
      this.dialog = true;
    },

    close() {
      this.dialog = false;
    },
    
    limpiar() {
      this.id = "";
      this.tipo_servicio = "";
      this.descripcion = "";
      this.costo_servicio = "";
    },
    
    nuevoObj() {
      this.editedIndex = -1;
      this.id = "";
      this.tipo_servicio = "";
      this.descripcion = "";
      this.costo_servicio = "";
    },

    guardar() {
      if (this.editedIndex > -1) {
        //Código para editar

        let me = this;
        axios 
          .put("api/servicios", {
            id: me.id,
            tipo_servicio: me.tipo_servicio,
            descripcion: me.descripcion,
            costo_servicio: me.costo_servicio
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
          .post("api/servicios", {
            tipo_servicio: me.tipo_servicio,
            descripcion: me.descripcion,
            costo_servicio: me.costo_servicio
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
