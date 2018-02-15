<template>
    <div>
        <div>
            <div class="nav-header">
                <div class="nav-header-container">
                    <div>
                        <div class="nav-header-sub">
                            <router-link class="RLwhite headDown3" :to="{name: 'Home'}">
                                <h1>TruckTool</h1>
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

            <h1 class="title">My Records</h1>
            <div class="recordCont">
                <table class="table table-bordered table-striped">
                    <thead>
                        <tr>
                            <th scope="col">Dot #</th>
                            <th scope="col">Company Name</th>
                            <th scope="col">Phone Number</th>
                            <th scope="col">Email Address</th>
                            <th scope="col">Company Rep</th>
                            <th scope="col">Company Rep 2</th>
                            <th scope="col">State</th>
                            <th scope="col">Docket</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr v-for="record in records">
                            <th scope="row">{{record.dot}}</th>
                            <td>{{record.census_DBA}}</td>
                            <td>{{record.censuS_CELL_PHONE_NUMBER}}</td>
                            <td>{{record.email}}</td>
                            <td>{{record.companY_REP_1}}</td>
                            <td>{{record.companY_REP_2}}</td>
                            <td>{{record.censuS_MAILING_ADDRESS_STATE}}</td>
                            <td>{{record.docket}}</td>
                        </tr>

                    </tbody>
                </table>


                <!-- <div id="keepButtons">
                                    <button @click="newTransactionToggle(record)" class="btn-xs btn-info">Transaction</button>
                             </div> -->
            </div>

        </div>



        <div class="center-container">
            <div class="transForm margin2 padding" v-if="newTransactionT">
                <form id="transForm1" @submit.prevent="newTransaction">
                    <div class="form-group fT-container">
                        <div class="form-group">
                            <div class="form-group">
                                <label class="" for="description">Dot #:</label>
                                <div class="regInput">
                                    <input type="text" size="15" name="name" placeholder="dot #" v-model="transaction.Dot" />
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="" for="status">Status:</label>
                                <div class="regInput">
                                    <!-- <input type="text" size="40" name="status" placeholder="Status" v-model="transaction.Status" /> -->
                                    <input type="radio" name="status" value="good" v-model="transaction.Status" checked> Good
                                    <input type="radio" name="status" value="in progress" v-model="transaction.Status"> In progress
                                    <input type="radio" name="status" value="bad" v-model="transaction.Status"> Bad
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="" for="inputName">Notes:</label>
                            <div class="regInput">
                                <textarea rows="4" cols="50" form="transForm1" v-model="transaction.Notes"></textarea>
                            </div>
                        </div>
                    </div>
                    <div>
                        <button @click="newTransactionToggle2" class="btn-sm" type="submit">Submit</button>
                    </div>
                </form>
            </div>
        </div>
        <div class="right-container">
            <h1 class="title">Weekly Transactions</h1>
        </div>
        <div class="right-container">
            <div class="transCont">
                <div class="row">
                    <div v-for="transaction in transactions">
                        <div class="col-xl-4 col-xs-6 mainDiv2">

                            <!-- v-if toggles all instances of keep. need to find better solution. -->
                            <!-- @click="setKeep(keep)" -->
                            <!-- <div>
                                    <img class="keepImg" :src="keep.imgUrl" alt="keep image">
                                </div>
                                <div>
                                    <p>{{keep.imgUrl}}</p>
                                    <p>
                                        {{keep.description}}
                                    </p>
                                </div>
                                <div class="keepStat-Container">
                                    <p>{{keep.views}}</p>
                                    <p>{{keep.keeps}}</p>
                                </div> -->

                            <div class="flex-container">

                                <div>
                                    <b>Dot #: </b>
                                    <p>{{transaction.dot}}</p>
                                </div>
                                <div>
                                    <b>Status</b>
                                    <p>{{transaction.status}}</p>
                                </div>
                                <div>
                                    <b>Notes: </b>
                                    <p>{{transaction.notes}}</p>

                                </div>
                            </div>


                            <!-- <div id="keepButtons" v-if="seen">
                                    <button @click="newTransactionToggle" class="btn-xs btn-info">Transaction</button>
                                </div> -->
                        </div>

                    </div>
                </div>
            </div>
            <!-- <vault></vault> -->
        </div>

        <div class="margin2">
            <form @submit="searchTransByDot">
                <input size="15" type="text" v-model="searchTD">
                <button class="btn-xs btn-info" type="submit">Search</button>
            </form>
        </div>
        <div class="flex-container">
            <div v-for="t in tdsearch">
                <div>
                    <b>Dot #: </b>
                    <p>{{t.dot}}</p>
                </div>
                <div>
                    <b>Status</b>
                    <p>{{t.status}}</p>
                </div>
                <div>
                    <b>Notes: </b>
                    <p>{{t.notes}}</p>

                </div>
            </div>
        </div>
    </div>
</template>


<script>

    export default {
        name: 'Home',
        data() {
            return {
                keep: {},
                transaction: {},
                newTransactionT: false,
                // activeTransaction: "",
                vaultkeep: {},
                seen: false,
                recordDetail: false,
                transactionDetail: false,
                searchTD: ""

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
            addToVault(keep) {
                console.log("keep")
                console.log(keep.id)
                console.log("Vault")
                console.log(this.vaultkeep.vaultId)
                this.vaultkeep.keepId = keep.id
                this.$store.dispatch('addToVault', this.vaultkeep)
                this.vaultkeep.vaultId = ""
            },
            newTransactionToggle(record) {
                console.log(record.dot)
                this.transaction.dot = record.dot
                console.log("here")
                this.newTransactionT = true
            },
            newTransactionToggle2(record) {
                this.newTransactionT = false
            },
            newTransaction() {

                this.$store.dispatch('authenticate')
                this.$store.dispatch('newTransaction', this.transaction)
            },
            searchTransByDot() {
                this.$store.dispatch('searchTransByDot', this.searchTD)
            },
            toggleRecordDetail() {
                this.recordDetail = !this.recordDetail
            },
            toggleTransactionDetail() {
                this.transactionDetail = !this.transactionDetail
            },
            // hideRecordDetail(index) {
            //     this.recordDetail = false
            //     this.record[index].addClass("hidden")
            // },
            // showRecordDetail(index) {
            //     this.recordDetail = true
            //     this.record[index].removeClass("hidden")
            // }
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
            records() {
                debugger
                var var1 = this.$store.state.activeRecords
                for (let i = 0; i < var1.length; i++) {
                    const element = var1[i];

                    if (element.docket == null || element.docket == "") {
                        element.docket = "--------"
                    }
                }
                return var1
            },
            transactions() {
                return this.$store.state.activeTransactions
            },
            vaults() {
                return this.$store.state.activeVaults
            },
            tdsearch() {
                console.log(this.$store.state.activeSTD)
                return this.$store.state.activeSTD
            }
        },
        mounted() {
            this.$store.dispatch('authenticate')
            console.log("what")
            console.log(this.user)
            this.$store.dispatch('getUserRecords', this.user.id)
            this.$store.dispatch('getUserTransactions')

        }
    }
</script>
<style>
    /* .headDown3 {
        position: relative;
        top: -1rem;
    } */

    .padding {
        padding: 1rem;
    }

    .marginright {
        margin-right: 2rem;
    }

    .transForm {
        background-color: rgb(205, 215, 255);
        width: 50vw;
        border-radius: 20px;
    }

    .flex-container {
        display: flex;
        justify-content: space-around
    }

    .margin2 {
        margin: 5rem;
    }

    .white {
        color: white;
    }

    .recordCont {
        background-color: rgb(205, 215, 255);
        width: 100vw;
        border-radius: 3px;
        border-top-style: solid;
    }

    .transCont {
        background-color: rgb(205, 215, 255);
        width: 50vw;
        border-radius: 3px;
        border-top-style: solid;
        border-left-style: solid;
    }

    .bgColor {
        background-color: blanchedalmond;
        width: 40rem;
    }

    .title {
        position: relative;
        /* right: 80rem; */
        color: black;
    }

    .glyphicon-plus-sign:hover,
    .glyphicon-minus-sign:hover {
        color: gray;
    }

    .block {
        display: block;
    }

    .center-container {
        display: flex;
        justify-content: center;
    }

    .right-container {
        display: flex;
        justify-content: flex-end;
        margin-top: 1rem
    }

    .fT-container {
        display: flex;
        justify-content: space-around;
    }
</style>