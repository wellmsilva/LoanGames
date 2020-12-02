<template>
  <v-dialog
    v-model="dialog"
    :persistent="true"
    width="50%"
    @keydown.esc="cancel"
  >
    <v-card class="usuario-log">
      <v-card-title>
        <span color="#fff" class="headline">Jogos emprestados</span>
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
              <td>{{ props.item.name }}</td>
              <td>{{ props.item.person }}</td>
              <td>{{ props.item.game }}</td>
            </template>
            <template v-slot:item.action="{ item }">
              <v-icon
                small
                class="mr-2"
                :disabled="item.dateReturn != null"
                @click="devolver(item)"
              >
                edit
              </v-icon>
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
export default {
  data() {
    return {
      dialog: false,
      items: [],
      headers: [
        { text: "Date", value: "date" },
        { text: "Pessoa", value: "person" },
        { text: "Jogo", value: "game" },
        {
          text: "Devolver",
          value: "action",
          sortable: false,
          align: "center",
          width: 120,
        },
      ],
    };
  },
  methods: {
    open(item) {
      this.dialog = true;
      this.items = item.loans;
    },
    devolver(item) {
      var loan = {
        game_Id: item.game_Id,
        person_Id: item.person_Id,
      };
      this.$emit("devolve", loan);
    },
    close() {
      this.dialog = false;
      this.items = [];
    },
  },
};
</script>