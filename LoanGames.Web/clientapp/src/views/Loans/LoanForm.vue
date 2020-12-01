<template>
  <v-dialog
    v-model="dialog"
    :persistent="true"
    width="50%"
    @keydown.esc="cancel"
  >
    <v-card class="usuario-log">
      <v-card-title>
        <span color="#fff" class="headline">Registra empréstimo</span>
        <v-spacer></v-spacer>
        <v-btn icon cicle @click="dialog = false">
          <v-icon>close</v-icon>
        </v-btn>
      </v-card-title>
      <v-card-text>
        <v-container>
          <v-row>
            <v-col cols="12" sm="12" md="12">
              <v-text-field
                label="Nome*"
                required
                v-model="person.name"
              ></v-text-field>
            </v-col>
            <v-col cols="12" sm="12" md="12">
              <v-text-field
                label="Telefone"
                hint="99999-9999"
                v-model="person.phone"
              ></v-text-field>
            </v-col>
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
export default {
  data: () => ({
    dialog: false,
    message: null,
    person: {
      id: "",
      name: "",
      phone: "",
    },
  }),
  computed: {
    panel() {
      return this.items.map((k, i) => i);
    },
  },
  methods: {
    open(item) {
      this.dialog = true;
      this.person = item;
    },
    save() {
      this.dialog = false;
      console.log(this.person);
    },
  },
};
</script>