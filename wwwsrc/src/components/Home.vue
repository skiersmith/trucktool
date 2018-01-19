<template>
    <div>
        <div>
            <div class="nav-header">
                <div class="nav-header-container">
                    <div>
                        <div class="nav-header-sub">
                            <router-link class="RLwhite headDown3" :to="{name: 'Home'}">
                                <h1>KEEPr</h1>
                            </router-link>
                        </div>
                    </div>

                    <div>
                        <p>Welcome, {{user.username}}</p>
                        <router-link class="RLwhite headDown3" :to="{name: 'Account'}">
                            <p>My Account</p>
                        </router-link>
                    </div>
                    <div>
                        <div class="nav-header-sub">
                            <span @click="userLogout">
                                <p class="white">Logout</p>
                            </span>
                        </div>
                    </div>
                </div>
            </div>
            <div class="spacer10"></div>

         
             
        <h1 class="title">All Keeps:</h1>
                <div class="keepCont">
                    <div class="row">
                        <div v-for="keep in keeps">
                            <div class="col-xl-4 col-xs-6 mainDiv">
                            <!-- @mouseover="keepButtonsShow(keep)" @mouseleave="keepButtonsHide(keep)" --> 
                            <!-- v-if toggles all instances of keep. need to find better solution. -->
                                <!-- @click="setKeep(keep)" -->
                                <div>
                                    <img class="keepImg" :src="keep.imgUrl" alt="keep image">
                                </div>
                                <div>
                                    <!-- <p>{{keep.imgUrl}}</p> -->
                                    <p>
                                        {{keep.description}}
                                    </p>
                                </div>
                                <div class="keepStat-Container">
                                    <p>{{keep.views}}</p>
                                    <p>{{keep.keeps}}</p>
                                </div>
                                
                                <div id="keepButtons" class="">
                                        <button @click="addToVaultToggle">Keep</button>
                                </div>
                                <div v-if="addToVaults">
                                        <form @change="addToVault(keep)">
                                            <p class="inline">Vault:</p>
                                            <select name="select vault" v-model="vaultkeep.vaultId">
                                                <option v-for="vault in vaults" :value="vault.id">{{vault.name}}</option>
                                            </select>
                                        </form>
                                </div>

                            </div>

                        </div>
                    </div>
                </div>
        </div>
        <!-- <vault></vault> -->

    </div>
</template>


<script>

    export default {
        name: 'Home',
        data() {
            return {
                keep: {},
                addToVaults: false,
                vaultkeep: {},
                // seen: false
            }
        },
        methods: {
            userLogout() {
                this.$store.dispatch('logout', this.$store.state.user._id)
            },
            authenticate() {
                this.$store.dispatch('authenticate')
            },
            toggleKeepForm() {
                this.keepForm = !this.keepForm
            },
            newKeep() {
                
                this.authenticate()
                // this.keep.userID = this.$store.state.user.id
                this.$store.dispatch('newKeep', this.keep)
            },
            getAllKeeps() {
                this.$store.dispatch('getAllKeeps')
            },
            deleteKeep(keep) {
                console.log(keep)
                this.$store.dispatch('deleteKeep', keep)
            },
            addToVault(keep){
                console.log("keep")
                console.log(keep.id)
                console.log("Vault")
                console.log(this.vaultkeep.vaultId)
                this.vaultkeep.keepId = keep.id 
                this.$store.dispatch('addToVault', this.vaultkeep)
                this.vaultkeep.vaultId = ""
            },
            addToVaultToggle(){
                
                this.addToVaults = !this.addToVaults
            },
            // keepButtonsShow(keep){
            //     // $(keep).find("keepButtons").removeClass("hidden")
            //     keep.getElementById("keepButtons").removeClass("hidden")
            // },
            // keepButtonsHide(keep){
            //     keep.getElementById("keepButtons").AddClass("hidden")
            //     // $(keep).find("keepButtons").AddClass("hidden")
            // }

        },
        computed: {
            user() {

                return this.$store.state.user
            },
            keeps() {


                return this.$store.state.activeKeeps
            },
            vaults(){
                return this.$store.state.activeVaults
            }
        },
        mounted() {
            this.$store.dispatch('getAllKeeps')
            this.$store.dispatch('authenticate')

        }
    }
</script>
<style>
    /* .headDown3 {
        position: relative;
        top: -1rem;
    } */

    .white {
        color: white;
    }

    .keepCont {
        background-color: rgb(205, 215, 255);
        width: 100vw

    }

    .bgColor {
        background-color: blanchedalmond;
        width: 40rem;
    }
    .title{
        position: relative;
        right: 80rem;
    }
</style>