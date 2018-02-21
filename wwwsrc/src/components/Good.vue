<template>
    <div>

        <table class="table table-bordered table-striped">
            <thead>
                <tr>
                    <th scope="col">Dot (click to expand)</th>
                    <th scope="col">Notes</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="t in gTransactions">
                    <th scope="row">{{t.dot}}</th>
                    <td>{{t.notes}}</td>
                </tr>
            </tbody>
        </table>







        <!-- <div class="mainDiv bg3">

            <div class="flex-container transactions1">

                <div>
                    <b>Dot #: </b>
                    <p>{{t.dot}}</p>
                </div>
                <div>
                    <b>Notes: </b>
                    <p>{{t.notes}}</p>
                </div>
            </div>
        </div> -->

    </div>
</template>
<script>
    export default {
        name: 'Good',
        data() {
            return {

            }
        },

        mounted() {
            this.$store.dispatch('getUserTransactions', this.user.id)

        },
        methods: {

        },
        computed: {
            user() {
                return this.$store.state.user
            },
            gTransactions() {
                return this.$store.state.activeGTransactions
            },
            oTransactions() {
                return this.$store.state.activeGTransactions
            },
            yTransactions() {
                return this.$store.state.activeGTransactions
            },

        },
    }
</script>
<style>
    bg3 {
        background-color: darkgreen;
    }
</style>