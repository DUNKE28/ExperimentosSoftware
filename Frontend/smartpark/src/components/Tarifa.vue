<template>
  <v-layout align-start>
    <v-flex>
      <v-toolbar flat color="white">
        <v-toolbar-title>Tarifas</v-toolbar-title>
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
                    <v-text-field v-model="monto" label="Monto"></v-text-field>
                    <v-text-field v-model="tipo_vehiculo" label="Tipo de vehiculo"></v-text-field>
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
      <v-data-table :headers="headers" :items="tarifas" :search="search" class="elevation-1">
        <template slot="items" slot-scope="props">
          <td class="justify-center layout px-0">
            <v-icon small class="mr-2" @click="editItem(props.item)">edit</v-icon>
          
          </td>
          <td>S/.{{ props.item.monto }}</td>
          <td>{{ props.item.tipo_vehiculo }}</td>
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
      tarifas: [],
      dialog: false,
      headers: [
        { text: "Opciones", value: "opciones", sortable: false },
        { text: "Monto", value: "monto", sortable: false },
        { text: "Tipo de vehiculo", value: "tipo_vehiculo", sortable: false }
      ],
      search: "",
      editedIndex: -1,

      //Model
      id: "",
      monto: "",
      tipo_vehiculo: ""
    };
  },
  computed: {
    formTitle() {
      return this.editedIndex === -1 ? "Nueva Tarifa" : "Actualizar Tarifa";
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
        .get("api/tarifas")
        .then(function(response) {
          console.log(response);
          me.tarifas = response.data;
        })
        .catch(function(error) {
          console.log(error);
        });
    },
    
    editItem(item) {
      this.id = item.id;
      this.monto = item.monto;
      this.tipo_vehiculo = item.tipo_vehiculo;

      this.editedIndex = 1;
      this.dialog = true;
    },


    close() {
      this.dialog = false;
    },
    
    limpiar() {
      this.id = "";
      this.monto = "";
      this.tipo_vehiculo = "";
    },
    
    nuevoObj() {
      this.editedIndex = -1;
      this.id = "";
      this.monto = "";
      this.tipo_vehiculo = "";
    },

    guardar() {
      if (this.editedIndex > -1) {
        //Código para editar
        let me = this;
        axios 
          .put("api/tarifas", {
            id: me.id,
            monto: me.monto,
            tipo_vehiculo: me.tipo_vehiculo
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
          .post("api/tarifas", {
            monto: me.monto,
            tipo_vehiculo: me.tipo_vehiculo
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
