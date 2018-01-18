<template>
<div>
    <p>tooooooyooooo</p>

    
    <div class="mainVault"> 
        <div v-for="keep in keeps">
            <div class="mainDiv">
                <div>
                    <p>Description</p>
                </div>
                <div>
                    <img src="http://via.placeholder.com/200x100" alt="">
                </div>
                <div>
                    <p>Url</p>
                    <p>
                        {{keep.description}}
                    </p>
                </div>
                <div class="keepStat-Container">
                    <p>Keeps: 0</p>
                    <p>Views: 0</p>
                    <p>S: 0</p>
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
                active: false,
            }
        },
        props: ['vault'],
        mounted(){
            console.log(this.vault.id)
            this.$store.dispatch('getKeepsAtVault', this.vault.id)

        },
        methods: {
            getVaultKeep(){
                console.log(this.vault.id)
                this.$store.dispatch('getKeepsAtVault', this.vault.id)
                
            }
        },
        computed: {
            user() {
                return this.$store.state.user
            },
            keeps() {
                return this.$store.state.activeVaultKeep
            },
            mouseOver(){
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