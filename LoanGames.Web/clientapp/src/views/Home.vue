<template>
  <div id="app" data-app>
    <!-- <div id="nav">
      <router-link to="/">Home</router-link> |
      <router-link to="/Persons">Pessoa</router-link> |
      <router-link to="/Games">Games</router-link> |
      <button v-on:click="logout()" v-show="logado">Sair</button>
    </div> -->
    <v-toolbar>
      <!-- Adjust the height to your needs, mine is 40 -->
      <v-toolbar-title>Title</v-toolbar-title>
      <v-spacer></v-spacer>
      <v-toolbar-items id="nav">
        <v-btn text><router-link to="/">Home</router-link></v-btn>
        <v-btn text><router-link to="/Persons">Pessoa</router-link></v-btn>
        <v-btn text><router-link to="/Games">Games</router-link></v-btn>
        <v-spacer></v-spacer>
        <v-btn text ><button v-on:click="logout()" v-show="logado">Sair</button></v-btn>
      </v-toolbar-items>
    </v-toolbar>
    <v-container> <router-view /> </v-container>
  </div>
</template>

<script>
import { logOut } from "@/services/utils";

export default {
  name: "Home",
  components: {},
  computed: {
    logado: () => sessionStorage.getItem("token") != null,
  },
  methods: {
    logout() {
      logOut();
      this.$router.push("/");
    },
  },
};
</script>
