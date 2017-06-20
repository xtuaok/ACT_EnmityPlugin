// 敵視リストが空のとき表示しない
var hideNoAggro = false;

// ロールの定義
var JobRole = {
    PLD: 'TANK',
    WAR: 'TANK',
    GLD: 'TANK',
    MRD: 'TANK',
    DRK: 'TANK',

    CNJ: 'HEALER',
    WHM: 'HEALER',
    SCH: 'HEALER',
    AST: 'HEALER',

    PGL: 'DPS',
    LNC: 'DPS',
    ARC: 'DPS',
    THM: 'DPS',
    MNK: 'DPS',
    DRG: 'DPS',
    BRD: 'DPS',
    BLM: 'DPS',
    ACN: 'DPS',
    SMN: 'DPS',
    ROG: 'DPS',
    NIN: 'DPS',
    MCH: 'DPS',
	SAM: 'DPS',
	RDM: 'DPS'
};

// フィルタ
Vue.filter('jobrole', function (v) {
    var role = JobRole[v.JobName];
    if (v.isPet) return "Pet";
    if (v.isMe) return "Me";
    if (role != null) return role;
    return "UNKNOWN";
});

var aggrolist = new Vue({
  el: '#aggrolist',
  data: {
    updated: false,
    locked: false,
    collapsed: false,
    encounter: null,
    combatants: null,
    hide: false
  },
  attached: function() {
    document.addEventListener('onOverlayDataUpdate', this.update);
    document.addEventListener('onOverlayStateUpdate', this.updateState);
  },
  detached: function() {
    document.removeEventListener('onOverlayStateUpdate', this.updateState);
    document.removeEventListener('onOverlayDataUpdate', this.update);
  },
  methods: {
    update: function(e) {
      this.updated = true;
      this.combatants = [];
      if (e.detail.Enmity.AggroList != null) {
        for (var i = 0; i < e.detail.Enmity.AggroList.length; i++) {
          var c = e.detail.Enmity.AggroList[i];
          var hp = c.HPPercent;
          if (hp < 25) {
            c.hpcolor = 'red';
          } else if (hp < 50) {
            c.hpcolor = 'orange';
          } else if (hp < 75) {
            c.hpcolor = 'yellow';
          } else {
            c.hpcolor = 'green';
          }
          if (c.HateRate == 100) {
            c.hatecolor = 'red';
          } else if (c.HateRate > 75) {
            c.hatecolor = 'orange';
          } else if (c.HateRate > 50) {
            c.hatecolor = 'yellow';
          } else {
            c.hatecolor = 'green';
          }
          this.combatants.push(c);
        }
      }
      this.hide = (hideNoAggro && this.combatants.length == 0);
    },
    updateState: function(e) {
      this.locked = e.detail.isLocked;
    },
    toggleCollapse: function() {
      this.collapsed = !this.collapsed;
    }
  }
});
