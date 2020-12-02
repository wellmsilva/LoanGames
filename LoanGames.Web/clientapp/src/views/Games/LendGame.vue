<template>
  <v-dialog
    v-model="dialog"
    :persistent="true"
    width="50%"
    @keydown.esc="cancel"
  >
    <v-card class="usuario-log">
      <v-card-title>
        <span color="#fff" class="headline">Cadastro de jogo</span>
        <v-spacer></v-spacer>
        <v-btn icon cicle @click="dialog = false">
          <v-icon>close</v-icon>
        </v-btn>
      </v-card-title>
      <v-card-text>
        <v-container>
          <v-row>
            <v-col cols="12" sm="12" md="12">
              <v-select
                v-model="loan.person_Id"
                :items="persons"
                label="Pessoa"
                item-text="name"
                item-value="id"
              ></v-select>
            </v-col>
            <!-- <v-col cols="12" sm="12" md="12">
              <v-text-field
                label="Nome*"
                required
                v-model="person.name"
              ></v-text-field>
            </v-col> -->
          </v-row>
        </v-container>
      </v-card-text>
      <v-card-actions>
        <v-spacer></v-spacer>
        <v-btn color="blue darken-1" text @click="dialog = false">Close</v-btn>
        <v-btn color="blue darken-1" text @click="save()">Save</v-btn>
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>

<script>
import { obtemPessoas } from "@/services/personService";

export default {
  data: () => ({
    dialog: false,
    message: null,
    isNovo: false,
    persons: [],
    loan: {
      person_Id: "",
      game_Id: "",
    },
  }),
  computed: {
    panel() {
      return this.items.map((k, i) => i);
    },
  },
  mounted() {
    this.carregaPessoas();
  },
  methods: {
    close() {
      this.dialog = false;
      this.loan = {
        person_Id: "",
        game_Id: "",
      };
    },
    open(item) {
      this.dialog = true;      
      this.loan.game_Id = item.id;
      console.log(this.loan);
    },
    carregaPessoas() {
      obtemPessoas()
        .then((res) => {
          this.persons = res.data;
        })
        .catch((err) => {
          console.log(err);
        });
    },
    save() {
      this.$emit("empresta", this.loan);
    },
  },
};
</script>