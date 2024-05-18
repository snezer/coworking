<script setup lang="ts">

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
            <li><a class="white-text" href="/">Личный кабинет</a></li>
            <li><a href="/">О нас</a></li>
          </ul>
        </nav>
      </div>
    </div>
    <div class="base">
      <div class="heading white-text">
        Коворкинг
      </div>
      <div class="description white-text">
        <span class="red-text">Хочешь поработать?</span> Мы знаем где можно...
      </div>
      <div class="actons">
        <Button style="background: white; color: #535bf2;">
          Выбрать место
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
}
.description{
  font-weight: 600;
  font-size: 1.2rem;
}
</style>
