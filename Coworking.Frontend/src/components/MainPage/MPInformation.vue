<script setup lang="ts">

defineEmits(['openmap'])
</script>

<template>
  <div class="information">
    <div class="header">
      <div class="logo">
        <span class="heading white-text">Pro<span class="heading" style="color: #ff0000">100</span>r</span>
      </div>
      <div class="navigation">
        <nav>
          <ul>
            <li><a class="white-text" href="/">Главная</a></li>
            <li><a class="white-text" href="/login">Личный кабинет</a></li>
            <li><a href="/">О нас</a></li>
          </ul>
        </nav>
      </div>
    </div>
    <div class="base">
      <div class="heading white-text">
        Выбираешь коворкинг?
      </div>
      <div class="description white-text" style="font-size: 32px;">
        <div style="display: flex;">
          <div>
          Мы знаем где ...
          </div>
        </div>

      </div>
      <div class="actons" style="padding-top: 20px; margin-left: -10px;">
        <Button text style="font-size: 1.5rem;" class="white-text">
          Открой двери в Про100R <i class="pi pi-sign-in" style="font-size: 2rem; margin-left: 10px"></i>
        </Button>
      </div>
    </div>
  </div>
</template>

<style scoped>
.information{
  position: relative;
  width: 100%;
  height: 100%;
  background-color: #535bf2;
  display: grid;
  grid-template-columns: 1fr;
  grid-template-rows: 80px 1fr;
  padding: 0 0 0 30px ;
  color: white !important;
}
.header{
  display: grid;
  grid-template-columns: 2fr 10fr;
  align-content: center;
}
.navigation{
  display: flex;
  justify-content: center;
  align-items: center;
  width: 100%;
}
.base{
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: flex-start;
  padding: 0 0 0 30px;
  gap: 10px
}
nav ul{
  width: 100%;
  display: flex;
  padding: 0;
  margin: 0;
  gap: 30px;
  list-style: none;
}
nav ul li a{
  text-decoration: none;
  color: white;
  font-size: 1.5rem;
}
.description{
  font-weight: 600;
  font-size: 1.2rem;
}
</style>
