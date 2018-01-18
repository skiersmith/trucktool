<template>
  <div id="app">

    <!-- <img src="./assets/logo.png"> -->
    <router-view/>
  </div>
</template>

<script>
  export default {
    name: 'app',
    method: {
      userLogout() {
        this.$store.dispatch('logout', this.$store.state.user._id)
      },
    },
    computed: {
      user() {
        console.log(this.$store.state.user)
        return this.$store.state.user
      },
    }
  }
</script>

<style>
  #app {
    font-family: 'Avenir', Helvetica, Arial, sans-serif;
    -webkit-font-smoothing: antialiased;
    -moz-osx-font-smoothing: grayscale;
    text-align: center;
    color: #2c3e50;
    margin-top: 60px;
  }

  .nav-header {
    background-color: rgb(103, 216, 160);
    height: 6rem;
    width: 100vw;
    top: 0px;
    position: fixed;
    left: 0px;
    /* display: flex; */
    /* justify-content: space-around; */
  }


  .spacer10 {
    height: 10rem;
  }

  .spacer1 {
    height: 2rem;
  }

  .spacer4 {
    height: 4rem;
  }

  .nav-header-container {
    display: flex;
    justify-content: space-around;
  }


  .mainVault {
    background-color: rgb(196, 231, 255);

  }

  .mainDiv {
    background-color: bisque;
    /* height: 20rem; */
    width: 30rem;
    margin: 1rem;
    padding: 1rem;
    /* display: flex;
    align-content: space-around; */
  }

  .mainDiv:hover {
    background-color: burlywood;
  }

  .keepStat-Container {
    display: flex;
    justify-content: space-around
  }
  .keepImg{
    max-width: 250px;
    max-height: 150px;
  }
</style>