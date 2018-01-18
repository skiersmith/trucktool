<template>
    <div class="keepCont">
        <div class="row">
            <div v-for="keep in keeps">
                <div class="col-xl-4 col-xs-6 mainDiv">
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
                    <div>
                        <button @click="deleteKeep(keep)">delete</button>
                    </div>

                </div>

            </div>
        </div>
    </div>
</template>


<script>

    export default {
        name: 'Keep',
        data() {
            return {
                keep: {},
                keepForm: false,
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
            }

        },
        computed: {
            user() {

                return this.$store.state.user
            },
            keeps() {


                return this.$store.state.activeKeeps
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
        background-color: blanchedalmond;

    }

    .bgColor {
        background-color: blanchedalmond;
        width: 40rem;
    }
</style>