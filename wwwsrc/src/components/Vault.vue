<template>
    <div>
        <router-link :to="{name: 'Account'}">
                <button>Back to account</button>
        </router-link>
        <h1>{{vault.name}}</h1>
        <div class="mainVault">
            <div v-for="keep in keeps">
                <div class="col-xl-4 col-xs-6 mainDiv">
                    <!-- @click="setKeep(keep)" -->
                   <button@click="deleteVK(keep)">x</button>
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
                </div>
            </div>
        </div>
    </div>
</template>
<script>
    export default {
        name: 'Vault',
        data() {
            return {
                vk: {},
                active: false,
            }
        },
        props: ['vault'],
        mounted() {
            console.log(this.vault.id)
            this.$store.dispatch('getKeepsAtVault', this.vault.id)

        },
        methods: {
            getVaultKeep() {
                console.log(this.vault.id)
                this.$store.dispatch('getKeepsAtVault', this.vault.id)

            },
            deleteVK(keep){
                keep.vaultId = this.vault.id
                this.$store.dispatch('deleteVK', keep)
            }
        },
        computed: {
            user() {
                return this.$store.state.user
            },
            keeps() {
                return this.$store.state.activeVaultKeep
            },
            mouseOver() {
                this.buttons = !this.buttons
            }
        },
    }
</script>
<style>
    .mainVault {
        background-color: rgb(196, 231, 255);

    }
</style>