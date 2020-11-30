<template>
  <div class="limiter">
    <h1>LOGIN</h1>
    <div class="container-login100">
      <div class="wrap-login100">
        <v-container fluid>
          <v-row align="center" justify="center">
            <v-card
              class="login100-form container-form"
              flat
              style="border-radius: 15px"
            >
              <v-card-text>
                <v-layout row wrap justify-center>
                  <v-flex xs10 sm10 lg9>
                    <v-text-field
                      light
                      label="Usuário"
                      single-line
                      v-model="user.username"
                      name="username"
                      type="text"
                      required
                      prepend-icon="email"
                    ></v-text-field>
                  </v-flex>
                  <v-flex xs10 sm10 lg9>
                    <v-text-field
                      label="Senha"
                      single-line
                      v-model="user.password"
                      name="password"
                      :rules="passwordRules"
                      required
                      prepend-icon="lock"
                      @keydown.enter="signin"
                    />
                  </v-flex>
                </v-layout>
              </v-card-text>
              <v-card-actions>
                <v-layout row wrap justify-center>
                  <v-flex xs10 sm10 lg9>
                    <v-btn
                      dark
                      depressed
                      block
                      color="#00253E"
                      style="border-radius: 7px; margin-bottom: 15px"
                      large
                      @click="signin()"
                      >Acessar</v-btn
                    >
                  </v-flex>
                  <v-flex
                    xs10
                    sm5
                    lg4
                    style="text-align: left"
                    v-if="!usuarioLogado"
                  >
                    <router-link
                      to="resetar-senha"
                      style="
                        text-decoration: none;
                        color: #082440;
                        font-size: 14px;
                        margin-bottom: 15px;
                      "
                      >Esqueceu a senha?</router-link
                    >
                  </v-flex>
                  <v-flex
                    xs10
                    sm5
                    lg5
                    style="text-align: right"
                    v-if="!usuarioLogado"
                  >
                    <router-link
                      to="solicita-acesso"
                      style="
                        text-decoration: none;
                        color: #082440;
                        font-size: 14px;
                        margin-bottom: 15px;
                      "
                      >Deseja solicitar acesso?</router-link
                    >

                    <!-- <a href @click.prevent="showSignup = !showSignup" style="text-decoration: none;">
                                        <span style="color:#082440;font-size:14px;margin-bottom: 15px;">Deseja solicitar acesso?</span>
                                    </a> -->
                  </v-flex>
                </v-layout>
              </v-card-actions>
            </v-card>
          </v-row>
        </v-container>
      </div>
    </div>
  </div>
</template>

<script >
import { login } from "@/services/userService";
import { setUser } from '@/services/utils';


export default {
  data() {
    return {
      usuarioLogado: true,
      loginEmail: "",
      loginPassword: "",
      valid: false,
      user: {
        username: "",
        password: "",
      },
      emailRules: [
        (v) => !!v || "E-mail é obrigatório",
        (v) => /.+@.+/.test(v) || "E-mail não é válido",
      ],
      nameRules: [(v) => !!v || "Nome é obrigatório"],
      passwordRules: [(v) => !!v || "Senha é obrigatório"],
    };
  },
  methods: {
    signin() {
      login(this.user)
        .then((result) => {
          setUser(result.data);
          this.$router.push('/')  
        })
        .catch((err) => {
          console.log(err);
        });
    },
  },
};
</script>

<style lang="css" scoped>
.limiter {
  width: 100%;
  margin: 0 auto;
}

.wrap-login100 {
  width: 400px;
  overflow: hidden;
  background: transparent;
  margin-left: auto;
  margin-right: auto;
  padding: 10px;
}

/*   [ Form ] */
.container-form {
  width: 700px;
  margin-left: auto;
  margin-right: auto;
}
.login100-form {
  max-width: 100%;
  border-radius: 15px;
  background-color: #fff;
  opacity: 0.8;
  padding: 25px 0px;
  /* padding-top: 15px;
    padding-bottom: 15px;*/
}

.login100-form-title {
  display: block;
  margin-left: auto;
  margin-right: auto;
  text-align: center;
}

.v-card__actions {
  padding: 10px 0;
}

.v-card__subtitle,
.v-card__text,
.v-card__title {
  padding: 0;
}
</style>