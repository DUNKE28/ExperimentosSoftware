<template>
  <v-app id="app">
    <v-navigation-drawer
      fixed
      :clipped="$vuetify.breakpoint.mdAndUp"
      app
      v-model="drawer"
    >
    <v-list class="pa-1" v-if="logeado">
        <v-list-tile avatar>
          <v-list-tile-avatar>
            <img src="https://randomuser.me/api/portraits/men/85.jpg">
          </v-list-tile-avatar>

          <v-list-tile-content>
            <v-list-tile-title v-if="admin == 1">Administrador: {{this.nombre}} {{this.apellido}}</v-list-tile-title>
            <v-list-tile-title v-if="admin == 0">Cajero: {{this.nombre}} {{this.apellido}}</v-list-tile-title>
          </v-list-tile-content>
        </v-list-tile>
      </v-list>
      <v-list dense class="pt-0">
         <v-divider></v-divider>
        <template v-if="!logeado">
          <v-list-tile :to="{name:'home'}">
            <v-list-tile-action>
              <v-icon>home</v-icon>
            </v-list-tile-action>
            <v-list-tile-title>
              Inicio
            </v-list-tile-title>
          </v-list-tile>
        </template>

        <template v-if="logeado">
          <v-list-group prepend-icon="tune">
            <v-list-tile slot="activator">
              <v-list-tile-content>
                <v-list-tile-title>
                  Mantenimiento
                </v-list-tile-title>
              </v-list-tile-content>
            </v-list-tile>

            <v-list v-if="admin == 0">
            <v-list-tile v-for="(item,i) in itemsCaj" :key="i" :to="{ name: item.router}">
              <v-list-tile-action>
                <v-icon class="material-design" >table_chart</v-icon>
              </v-list-tile-action>
              <v-list-content>
                <v-list-tile-title v-text="item.text">
                </v-list-tile-title>
              </v-list-content>
            </v-list-tile>
            </v-list>

            <v-list v-if="admin == 1">
            <v-list-tile v-for="(item,i) in itemsAdm" :key="i" :to="{ name: item.router}">
              <v-list-tile-action>
                <v-icon class="material-design" >table_chart</v-icon>
              </v-list-tile-action>
              <v-list-content>
                <v-list-tile-title v-text="item.text">
                </v-list-tile-title>
              </v-list-content>
            </v-list-tile>
            </v-list>

          </v-list-group>
        </template>
      </v-list>
      <v-list dense v-if="logeado">
        <v-divider></v-divider>
        <template>
          <v-subheader>
            Actions
          </v-subheader>
          <v-list-tile @click="close()">
            <v-list-tile-action>
              <v-icon class="material-design">open_in_new</v-icon>
            </v-list-tile-action>
            <v-list-content>
              <v-list-tile-tile>
                Sign Out
              </v-list-tile-tile>
            </v-list-content>
          </v-list-tile>
        </template><v-list-content>
          
        </v-list-content>
      </v-list>
    </v-navigation-drawer>
    <v-toolbar
      color="secondary"
      dark
      app
      :clipped-left="$vuetify.breakpoint.mdAndUp"
      fixed
    >
     <v-toolbar-side-icon @click.stop="drawer = !drawer"></v-toolbar-side-icon>
      <v-toolbar-title style="width: 300px" class="ml-0 pl-3">
        <span class="hidden-sm-and-down font-weight-thin headline">SmartPark</span>
      </v-toolbar-title>
    </v-toolbar>
    <v-content>
      <v-container fluid fill-height>
        <v-slide-y-transition mode="out-in">
          <router-view/>
        </v-slide-y-transition>
      </v-container>
    </v-content>
    <v-footer dark height="auto">
      <v-layout justify-center>
        <v-flex text-xs-center>
          <v-card flat tile color="primary" class="white--text">
            <v-card-text class="white--text pt-0">
             SmartPark &copy;2019
            </v-card-text>
          </v-card>
        </v-flex>
      </v-layout>
    </v-footer>

  </v-app>
</template>


<script>

export default {
  name: 'App',
  data () {
    return {
      drawer: false,
      itemsAdm: [{text:"Cajero",router:"cajeros"},{text:"Vehiculo",router:"vehiculos"},{text:"Tarifa",router:"tarifas"},{text:"Servicio",router:"servicios"},{text:"Comprobante",router:"comprobantes"},{text:"Parking",router:"parkings"},{text:"Espacio",router:"espacios"},{text:"Administrador",router:"administradores"}],
      itemsCaj: [{text:"Ingreso",router:"ingresos"}],
      admin: localStorage.getItem('admin'),
      nombre: localStorage.getItem('nombre'),
      apellido: localStorage.getItem('apellido'),
      logeado: localStorage.getItem('logeado'),
    }
  },
  methods: {
    close() {
        localStorage.removeItem('admin')
        localStorage.removeItem('nombre')
        localStorage.removeItem('apellido')
        localStorage.removeItem('logeado')
        localStorage.removeItem('contraseña')
        localStorage.removeItem('username')
        localStorage.removeItem('parking')
        localStorage.removeItem('id')
        window.parent.location.reload()
        window.top.location.href = "/"
    }
  }
}
</script>
