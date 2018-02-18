<template>
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
                    <router-link class="RLwhite headDown3" :to="{name: 'Good'}">
                        <p>HOT LEADS</p>
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
        <div>
            <div class="row margin2">






                <h1 class="title">My Records</h1>
                <button @click="tableTimeToggle">TableTimeToggle</button>
                <h1>{{tableTimeZone1}}</h1>

                <div class="col-lg-8 recordCont">
                    <table v-if="tableTimeZone == 3" class="table table-bordered table-striped">
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
                                <th scope="col">------</th>
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
                                <td>
                                    <button class="btn-xs" @click="copyDot(record.dot)">Copy</button>
                                </td>
                            </tr>

                        </tbody>
                    </table>
                    <table v-if="tableTimeZone == 2" class="table table-bordered table-striped">

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
                                <th scope="col">------</th>
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
                                <td>
                                    <button class="btn-xs" @click="copyDot(record.dot)">Copy</button>
                                </td>
                            </tr>

                        </tbody>
                    </table>
                    <table v-if="tableTimeZone == 1" class="table table-bordered table-striped">

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
                                <th scope="col">------</th>
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
                                <td>
                                    <button class="btn-xs" @click="copyDot(record.dot)">Copy</button>
                                </td>
                            </tr>

                        </tbody>
                    </table>


                </div>




                <div class="col-lg-4 center-container">
                    <div class="transForm padding" v-if="newTransactionT">
                        <form id="transForm1" @submit.prevent="newTransaction">
                            <div class="form-group fT-container">

                                <div class="form-group flex-container padding">
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
                                            <input type="radio" name="status" value="green" v-model="transaction.Status" checked> Good
                                            <input type="radio" name="status" value="orange" v-model="transaction.Status"> Orange
                                            <input type="radio" name="status" value="yellow" v-model="transaction.Status"> Yellow
                                            <input type="radio" name="status" value="red" v-model="transaction.Status"> Remove
                                        </div>
                                    </div>
                                </div>
                                <div class="spacer4"></div>
                                <div class="form-group padding">
                                    <label class="" for="inputName">Notes:</label>
                                    <div class="regInput">
                                        <textarea rows="4" cols="50" form="transForm1" v-model="transaction.Notes"></textarea>
                                    </div>
                                </div>
                            </div>
                            
                            <div class="margin3">
                                <button class="btn-sm" type="submit">Submit</button>
                            </div>
                        </form>
                        <!-- <div class="topMargin">
                            <form @submit="searchTransByDot">
                                <input size="15" type="text" v-model="searchTD">
                                <button class="btn-xs btn-info" type="submit">Search</button>
                            </form>
                        </div> -->
                        <div class="transactions2">
                            <div class=" mainDiv2 bg2">
                                <div v-for="z in yTransactions">


                                    <div class="flex-container transactions1">

                                        <div>
                                            <b>Dot #: </b>
                                            <p>{{z.dot}}</p>

                                        </div>
                                        <div>
                                            <b>Notes: </b>
                                            <p>{{z.notes}}</p>

                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div v-for="t in oTransactions">
                                <div class="mainDiv2 bg1">

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
                                </div>
                            </div>
                        </div>

                        <!-- <div class="mainDiv2 bg2">
                            <div class="flex-container">
                                <div>
                                    <b>Dot #: </b>
                                    <p>{{yTransactions.dot}}</p>
                                </div>
                                <div>
                                    <b>Notes: </b>
                                    <p>{{yTransactions.notes}}</p>
                                </div>
                            </div>
                        </div>
                        <div class="mainDiv2 bg1">
                            <div class="flex-container">
                                <div>
                                    <b>Dot #: </b>
                                    <p>{{oTransactions.dot}}</p>
                                </div>
                                <div>
                                    <b>Notes: </b>
                                    <p>{{oTransactions.notes}}</p>
                                </div>
                            </div>
                        </div> -->
                    </div>
                </div>




            </div>

        </div>


        <div class="right-container">
            <h1 class="title">Weekly Transactions</h1>
        </div>
        <div class="right-container">
            <div class="transCont">
                <div class="row">

                </div>
            </div>
            <!-- <vault></vault> -->
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
                transaction: {
                    Dot: ""
                },
                newTransactionT: true,
                // activeTransaction: "",
                vaultkeep: {},
                seen: false,
                recordDetail: false,
                transactionDetail: false,
                searchTD: "",
                tableTimeZone: 1

            }
        },
        methods: {
            copyDot(dot) {
                this.transaction.Dot = dot
                this.$store.dispatch('searchTransByDot', dot)

            },
            tableTimeToggle() {
                if (this.tableTimeZone < 3) {
                    this.tableTimeZone++
                }
                else {
                    this.tableTimeZone = 1
                }

            },
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

            newTransaction() {
                
                
                this.$store.dispatch('authenticate')
                this.$store.dispatch('newTransaction', this.transaction)
                this.transaction = {}
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
            tableTimeZone1() {
                return this.tableTimeZone
            },
            user() {

                return this.$store.state.user
            },
            records() {

                var var1 = this.$store.state.activeRecords
                for (let i = 0; i < var1.length; i++) {
                    const element = var1[i];

                    if (element.docket == null || element.docket == "") {
                        element.docket = "--------"
                    }
                }
                return var1
            },
            yTransactions() {
                console.log("p")

                console.log(this.$store.state.activeYTransactions)
                return this.$store.state.activeYTransactions
            },
            oTransactions() {
                return this.$store.state.activeOTransactions
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

            this.$store.dispatch('getUserRecords', this.user.id)
            // this.$store.dispatch('getUserTransactions')

        }
    }
</script>
<style>
   
    .transactions1 {
        border-top-style: solid;
        border-bottom-style: solid;
        border-bottom-width: 1px;
        border-top-width: 1px;
        padding: 0.5rem;
        /* border-radius: 25px; */
    }

    .transactions2 {
        padding: 1rem;
    }

    .bg2 {
        background-color: rgba(252, 255, 80, 0.719);
    }

    .bg1 {
        background-color: rgba(248, 145, 10, 0.726);
    }

    .padding {
        padding: 1rem;
    }

    .marginright {
        margin-right: 2rem;
    }

    .transForm {
        background-color: rgb(205, 215, 255);
        /* width: 50vw; */
        border-radius: 20px;
    }

    .flex-container {
        display: flex;
        justify-content: space-around
    }

    .margin2 {
        margin: 5rem;
    }

    .margin3 {
        margin-bottom: 1rem;
    }

    .white {
        color: white;
    }

    .recordCont {
        background-color: rgb(205, 215, 255);
        /* width: 80vw; */
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
        top: 120px;
        position: sticky;
        /* height: 0rem; */
        /* width: 20rem; */
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

    .topMargin {
        margin-top: 4rem;
    }
</style>