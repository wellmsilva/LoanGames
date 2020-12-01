<template>
  <div class="pessoa">
    <h1>Meus Jogos</h1>
    <div style="padding: 10px">
      <v-btn small @click="novoItem()">Novo</v-btn>
    </div>
    <v-data-table
      :headers="headers"
      :items="items"
      :loading="true"
      class="elevation-1"
    >
      <template v-slot:progress color="blue" indeterminate></template>
      <template v-slot:items="props">
        <td>{{ props.item.name }}</td>
      </template>

      <template v-slot:item.action="{ item }">
        <v-icon small class="mr-2" @click="editItem(item)"> edit </v-icon>
        <v-icon small class="mr-2" @click="deleteItem(item)"> delete </v-icon>
        <v-icon small class="mr-2" @click="emprestaItem(item)">
          remove_red_eye
        </v-icon>
      </template>
    </v-data-table>

    <game-form ref="gameForm" />
  </div>
</template>

<script>
import GameForm from "./GameForm.vue";
import { obtemTodos, exclueGame } from "@/services/gameService";

export default {
  name: "Home",
  components: { GameForm },
  data() {
    return {
      progress: false,
      headers: [
        { text: "Nome", value: "name" },
        {
          text: "Ações",
          value: "action",
          sortable: false,
          align: "center",
          width: 120,
        },
      ],
      items: [{ id: "1", name: "Lol ", phone: "" }],
    };
  },
  mounted() {
    this.carregaDados();
  },
  methods: {
    editItem(item) {
      this.$refs.gameForm.open(item, false);
    },
    novoItem() {
      this.$refs.gameForm.open({}, true);
    },
    deleteItem(item) {
      exclueGame(item.id)
        .then(() => {
          this.carregaDados()
        })
        .catch((err) => {
          console.log(err);
        });
    },
    emprestaItem(item) {
      this.$refs.emprestaForm.open(item);
    },
    carregaDados() {
      obtemTodos()
        .then((result) => {
          this.items = result.data;
        })
        .catch((err) => {
          console.log(err);
        });
    },
  },
};
</script>
