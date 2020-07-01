<template>
  <v-container>
    <v-layout>
      <v-btn class="ma-2"  color="dark" @click.native="iniReg">Registrate</v-btn>
      <v-spacer></v-spacer>
      <v-btn class="ma-2"  color="dark" @click.native="iniAd">Login Administrador</v-btn>
      <v-btn class="ma-2"  color="dark" @click.native="iniCaj">Login Cajero</v-btn>
    </v-layout>
    <v-card >
        <v-img src="https://static.comunicae.com/photos/notas/1192439/1515419868_np_enero.jpg"
        height="400"
        >
        </v-img>
    </v-card>
    <v-layout
      text-xs-center
      wrap
    >

      <v-flex xs12>
        <v-card class="mx-auto">
          <v-img
            src="https://hackster.imgix.net/uploads/attachments/917796/smartpark_wqdiHhCJOh.jpg?auto=compress%2Cformat&w=900&h=675&fit=min"
            class="my-3"
            contain
            height="300"
          ></v-img>
          <v-card-text class="text--primary">
            <p class="font-italic title">
              Esta aplicación está destinada para gestionar las playas de estacionamiento
              <br>de pymes. Brindando un buen control del negocio,  permitiendo agilizar
              <br>los procesos de ingreso de vehículos y de gestión de las ganancias generadas.
            </p>
          </v-card-text>
        </v-card>
      </v-flex>
      <v-flex xs12 sm6> 
        <v-card class="mx-auto">
          <v-img
            src="https://i.imgur.com/UPbVsIT.png"
          ></v-img>
        </v-card>
      </v-flex>
      <v-flex xs12 sm6>
        <v-card class="mx-auto">
          <v-img
            src="https://i.imgur.com/46Ez7Tq.png"
            contain
            height="335"
          ></v-img>
        </v-card>
      </v-flex>
      <v-flex xs12>
        <v-card class="mx-auto">
          <v-img
            src="https://i.imgur.com/InklUrM.png"
            contain
            height="197"
          ></v-img>
        </v-card>
      </v-flex>

      <v-dialog persistent v-model="adm" max-width="500px">
          <v-card>
            <v-card-title>
              <span class="headline">Iniciar Sesion como Administrador</span>
            </v-card-title>

            <v-card-text>
              <v-container grid-list-md>
                <v-layout wrap>
                  <v-flex xs12 sm12 md12>
                    <v-text-field prepend-icon="person" v-model="username" label="Nombre de usuario"></v-text-field>
                    <v-text-field prepend-icon="lock" v-model="contraseña" type='password' label="Contraseña"></v-text-field>
                  </v-flex>
                </v-layout>
              </v-container>
            </v-card-text>

            <v-card-actions>
              <v-spacer></v-spacer>
              <v-btn color="blue darken-1" flat @click.native="close">Cancelar</v-btn>
              <v-btn color="blue darken-1" flat @click.native="iAdm">Iniciar Sesion</v-btn>
            </v-card-actions>
          </v-card>
        </v-dialog>

        <v-dialog persistent v-model="caj" max-width="500px">
          <v-card>
            <v-card-title>
              <span class="headline">Iniciar Sesion como Cajero</span>
            </v-card-title>

            <v-card-text>
              <v-container grid-list-md>
                <v-layout wrap>
                  <v-flex xs12 sm12 md12>
                    <v-text-field prepend-icon="person" v-model="username" label="Nombre de usuario"></v-text-field>
                    <v-text-field prepend-icon="lock" v-model="contraseña" type='password' label="Contraseña"></v-text-field>
                        <v-select prepend-icon="directions_car" v-model="parking" :items="parkings" item-text="name" item-value="id" label="Parking">
                        </v-select>
                  </v-flex>
                </v-layout>
              </v-container>
            </v-card-text>

            <v-card-actions>
              <v-spacer></v-spacer>
              <v-btn color="blue darken-1" flat @click.native="close">Cancelar</v-btn>
              <v-btn color="blue darken-1" flat @click.native="iCaj">Iniciar Sesion</v-btn>
            </v-card-actions>
          </v-card>
        </v-dialog>


        <v-dialog persistent v-model="reg" max-width="500px">
          <v-card>
            <v-card-title>
              <span class="headline">Registrarse como administrador</span>
            </v-card-title>

            <v-card-text>
              <v-container grid-list-md>
                <v-layout wrap>
                  <v-flex xs12 sm12 md12>
                    <v-text-field prepend-icon="person" v-model="username" label="Nombre de usuario"></v-text-field>
                    <v-text-field prepend-icon="person" v-model="nombre_adm" label="Nombre"></v-text-field>
                    <v-text-field prepend-icon="person" v-model="apellido_adm" label="Apellido"></v-text-field>
                    <v-text-field prepend-icon="lock" type="password" v-model="contraseña" label="Contraseña"></v-text-field>
                    <v-text-field prepend-icon="lock" type="password" v-model="conaux" label="Repetir contraseña"></v-text-field>
                    <v-checkbox v-model="checkbox" :label="`Acepto los terminos y condiciones de SmartPark`"></v-checkbox>
                  </v-flex>
                </v-layout>
              </v-container>
            </v-card-text>

            <v-card-actions>
              <v-spacer></v-spacer>
              <v-btn color="blue darken-1" flat @click.native="close">Cancelar</v-btn>
              <v-btn color="blue darken-1" flat @click.native="guardar">Registrarse</v-btn>
            </v-card-actions>
          </v-card>
        </v-dialog>

        
    </v-layout>
  </v-container>
</template>

<script>
  import axios from 'axios'
  export default {
    data: () => ({
      checkbox: false,
      adm: false,
      caj: false,
      reg: false,
      parkings: [],

      parking: '',
      username: '',
      nombre_adm: '',
      apellido_adm: '',
      contraseña: '',
      conaux: '',
    }),
    
    created() {
      this.loadParking();
    },

    methods: {
      loadParking(){
        let me = this;
      axios
        .get("api/parkings")
        .then(function(response) {
          console.log(response.data);
          response.data.forEach(function (params) {
            me.parkings.push({
            id: params.id,
            name: params.nombre_estacionamiento,
          });
          })
          
       })
        .catch(function(error) {
          console.log(error);
        });
      },

      guardar(){
        if(this.checkbox){
          if(this.contraseña == this.conaux){
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
                alert('Se registró administrador correctamente.')
              })
              .catch(function(error) {
                console.log(error);
                //me.error=true;
              });
          } else{
            alert('Las contraseñas son diferentes.')
          }
        } else{
          alert('Tienes que aceptar los terminos y condiciones.')
        }
      },

      close(){
        this.adm = false;
        this.caj = false;
        this.reg = false;
        this.parking = '';
        this.username = '';
        this.nombre_adm = '';
        this.apellido_adm = '';
        this.contraseña = '';
      },

      iniAd(){
        this.adm = true;
      },
      iniCaj(){
        this.caj = true;
      },
      iniReg(){
        this.reg = true;
      },
      iAdm(){
        let me = this;
        axios.get('api/administradores/'+me.username+'/'+me.contraseña)
        .then(function (response) {
            console.log(response.data)
            if (response.data) {
                localStorage.setItem('username',me.username)
                localStorage.setItem('contraseña',me.contraseña)
                localStorage.setItem('nombre',response.data.nombre_adm)
                localStorage.setItem('apellido',response.data.apellido_adm)
                localStorage.setItem('logeado', true)
                localStorage.setItem('admin', 1)
                localStorage.setItem('id',response.data.id)
                window.top.location.href = "/parkings"
            } else {
              alert('Contraseña o usuario incorrectos.')
            }
        }).catch(function (error) {
            console.log(error);
        });
      },
      iCaj(){
        let me = this;
        axios.get('api/cajeros/'+me.username+'/'+me.contraseña)
        .then(function (response) {
            console.log(response.data)
            if (response.data) {
                localStorage.setItem('username',me.username)
                localStorage.setItem('contraseña',me.contraseña)
                localStorage.setItem('nombre',response.data.nombre_Cajero)
                localStorage.setItem('apellido',response.data.apellido_Cajero)
                localStorage.setItem('logeado', true)
                localStorage.setItem('parking', me.parking)
                localStorage.setItem('admin', 0)
                localStorage.setItem('id',response.data.id)
                window.top.location.href = "/ingresos"
            } else {
              alert('Contraseña o usuario incorrectos.')
            }
        }).catch(function (error) {
            console.log(error);
        });
      },
    }
  }
</script>

<style>

</style>
