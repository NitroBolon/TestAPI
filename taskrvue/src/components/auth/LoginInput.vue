<template>
    <LoginForm></LoginForm>
</template>

<script lang="ts">
import { defineComponent } from 'vue';
import LoginForm from "./parts/LoginForm.vue";

export default defineComponent ({
  name: 'LoginInput',
  components: {
    LoginForm
  }
});
</script>

<style>
    
</style>