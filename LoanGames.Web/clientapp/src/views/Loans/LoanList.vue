<template>
  <div class="pessoa">
    <h1>Emprestados</h1>
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

      
    </v-data-table>

    <loan-form ref="loanForm" />
  </div>
</template>

<script>
import LoanForm from "./LoanForm.vue";
import { obtemTodos } from "@/services/loanService";

export default {
  name: "Home",
  components: {
    LoanForm,
  },
  data() {
    return {
      progress: false,
      headers: [
        { text: "Date", value: "date" },
        { text: "Pessoa", value: "person" },
        { text: "Jogo", value: "game" },
        {
          text: "Ações",
          value: "action",
          sortable: false,
          align: "center",
          width: 120,
        },
      ],
      items: [],
    };
  },
  mounted(){
    this.carregaDados();
  },
  methods: {

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
