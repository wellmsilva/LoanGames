<template>
  <v-dialog
    v-model="dialog"
    :persistent="true"
    width="50%"
    @keydown.esc="cancel"
  >
    <v-card class="usuario-log">
      <v-card-title>
        <span color="#fff" class="headline">Jogo Emprestado</span>
        <v-spacer></v-spacer>
        <v-btn icon cicle @click="dialog = false">
          <v-icon>close</v-icon>
        </v-btn>
      </v-card-title>
      <v-card-text>
        <v-container>       
            <v-data-table
              :headers="headers"
              :items="items"
              :loading="true"
              class="elevation-1"
            >
              <template v-slot:items="props">                
                <td>{{ props.item.person }}</td>
                <td>{{ props.item.game }}</td>
                <td>{{ props.item.ativo }}</td>
              </template>
            </v-data-table>   
        </v-container>
      </v-card-text>
      <v-card-actions>
        <v-spacer></v-spacer>
        <v-btn color="blue darken-1" text @click="dialog = false">Close</v-btn>
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>

<script>
// import { cadastraGame, editaGame } from "@/services/gameService";

export default {
  data: () => ({
    dialog: false,
    message: null,
    isNovo: false,
    person: {
      id: "",
      name: "",
      phone: "",
    },
    headers: [
      { text: "Pessoa", value: "person" },
      { text: "Jogo", value: "game" },
      { text: "Ativo", value: "ativo" }
    ],
  }),
  computed: {
    panel() {
      return this.items.map((k, i) => i);
    },
  },
  methods: {
    open(item) {
      this.dialog = true;
      this.items = item.loans;
      console.log(item);
    },
  },
};
</script>