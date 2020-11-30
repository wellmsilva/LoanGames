<template>
  <div class="pessoa">
    <h1>Meus Jogos</h1>
    <v-data-table
      :headers="headers"
      :items="items"
      :loading="true"
      class="elevation-1"
    >
      <v-progress-linear
        v-slot:progress
        color="blue"
        indeterminate
      ></v-progress-linear>
      <template v-slot:items="props">
        <td>{{ props.item.name }}</td>
        <td class="text-xs-right">{{ props.item.calories }}</td>
        <td class="text-xs-right">{{ props.item.fat }}</td>
        <td class="text-xs-right">{{ props.item.carbs }}</td>
        <td class="text-xs-right">{{ props.item.protein }}</td>
        <td class="text-xs-right">{{ props.item.iron }}</td>
      </template>
    </v-data-table>
  </div>
</template>

<script>
// @ is an alias to /src

export default {
  name: "Home",
  components: {},
  data() {
    return {
      progress: false,
      headers: [
        { text: "Nome", value: "name" },
        { text: "Telefone", value: "phone" },
      ],
      items: [{ id: "1", name: "WEllington ", phone: "" }],
    };
  },
  created() {
    //console.log("aqui");
  },
};
</script>
