<script setup lang="ts">

import {ref, unref} from "vue";

const registrationFormVisible = ref<boolean>(false);

import router from "../router.ts";
import {useAppStore} from "../store/useAppStore.ts";

const login = ref<string>('')
const password = ref<string>('')
const isLoading = ref<boolean>(false)
const appStore = useAppStore()

const handleLogin = async () => {
  isLoading.value = true
  // await authService.login(unref(login), unref(password))
  // if (authService.checkHasIsAuth()) {
  //   await router.push({ path: '/home' })
  // }
  router.push({ path: '/dashboard/main' })
  isLoading.value = false
}
</script>

<template>
  <div id="login-wrapper">
    <div style="display: flex; justify-content: center; align-items:center; width: 100%; height: 100%">
      <form action="" style="">
        <div class="p-fluid p-grid">
          <div class="p-col-12">
            <span class="heading">Pro<span class="heading red-text">100</span>r</span>
          </div>
        </div>
        <div class="p-fluid p-grid login-gap" style="margin-top: 10px">
          <div class="p-field p-col-12">
          <span class="p-float-label">
            <InputText
                id="login"
                v-model:model-value="login"
                @keyup.enter="handleLogin"
            />
            <label for="login">Логин</label>
          </span>
          </div>
          <div class="p-field  p-col-12" style="margin-top: 25px;">
          <span class="p-float-label">
            <Password
                id="password"
                v-model:model-value="password"
                :feedback="false"
                @keyup.enter="handleLogin"
            />
            <label for="password">Пароль</label>
          </span>
          </div>
          <div class="p-field p-col-12" style="margin-top: 25px;">
            <Button
                label="Войти"
                :loading="isLoading"
                @click="handleLogin"
            />
          </div>
        </div>
      </form>
    </div>
    <div>

    </div>
  </div>
</template>

<style scoped>
#login-wrapper{
  position: absolute;
  height: 100vh;
  width: 100vw;
  display: grid;
  grid-template-columns: 1fr;
  align-content: center;
  overflow: hidden;
}

.primary-block{
  position: absolute;
  width: 50vw;
  height: 100vh;
  left: 50vw;
  background: var(--primary);
  transition: left .5s cubic-bezier(.4,2.08,.55,.5);
}
.primary-block.registration{
  left: 0;
}

</style>