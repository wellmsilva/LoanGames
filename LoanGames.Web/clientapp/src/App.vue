<template>
  <div id="app" data-app>
    <div id="nav">
      <router-link to="/">Home</router-link> |
      <router-link to="/Persons">Pessoa</router-link> |
      <router-link to="/Games">Games</router-link> |
      <button v-on:click="logout()" v-show="logado">Sair</button>
    </div>
    <router-view />
  </div>
</template>

<script>
import { logOut } from '@/services/utils';


export default {
  computed: {
    logado: () => sessionStorage.getItem("token") != null,
  },
  methods:{
    logout(){
      logOut();
      this.$router.push('/')  
    }
  }
};
</script>

<style lang="scss">
#app {
  font-family: "Avenir", Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}

#nav {
  padding: 30px;

  a {
    font-weight: bold;
    color: #2c3e50;

    &.router-link-exact-active {
      color: #42b983;
    }
  }
}
</style>
