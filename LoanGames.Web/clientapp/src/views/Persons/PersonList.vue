<template>
  <div class="pessoa">
    <h1>Pessoas</h1>
    <v-data-table
      :headers="headers"
      :items="persons"
      :loading="progress"
      class="elevation-1"
    >
      <template v-slot:items="props">
        <td>{{ props.item.name }}</td>
        <td class="text-xs-right">{{ props.item.phone }}</td>
      </template>

      <template v-slot:item.action="{ item }">
        <v-icon small class="mr-2" @click="editItem(item)"> edit </v-icon>
        <v-icon small class="mr-2" @click="deleteItem(item)"> delete </v-icon>
        <v-icon small class="mr-2" @click="logItem(item)">
          remove_red_eye
        </v-icon>
      </template>
    </v-data-table>

    <PersonEdit ref="personEdit" />
  </div>
</template>

<script>
import { obtemPessoas, excluePessoa } from "@/services/personService";
import PersonEdit from "./PersonEdit";

export default {
  name: "Home",
  components: {
    PersonEdit,
  },
  data() {
    return {
      progress: false,
      dialogEdit: false,
      headers: [
        { text: "Nome", value: "name" },
        { text: "Telefone", value: "phone" },
        {
          text: "Ações",
          value: "action",
          sortable: false,
          align: "center",
          width: 120,
        },
      ],
      persons: [],
    };
  },
  mounted() {
    this.carregaPessoas();
  },
  methods: {
    carregaPessoas() {
      this.progress = true;
      obtemPessoas()
        .then((res) => {
          this.persons = res.data;
          this.progress = false;
        })
        .catch((err) => {
          console.log(err);
          this.progress = false;
        });
    },
    editItem(item) {
      this.$refs.personEdit.open(item);
      this.dialogEdit = true;
    },
    deleteItem(item) {
      excluePessoa(item.id)
        .then((res) => {
          console.log(res);
        })
        .catch((err) => {
          console.log(err);
        });
    },
  },
};
</script>

<style scoped>
.blue {
  background: #2c3e50;
}
</style>