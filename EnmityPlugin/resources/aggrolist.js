Vue.directive('combatant', {
  update: function(value) {
    var ds = this.el.dataset;
    ds.deaths = value.deaths;
  }
});

// デバッグ用
var debugList = {
  detail: {
    Enmity: {
      AggroList: [
        {
          Name: '木人A',
          HateRate: 100,
          HPPercent: "23.34"
        },
        {
          Name: '木人B',
          HateRate: 43,
          HPPercent: "68.80"
        },
        {
          Name: '木人C',
          HateRate: 74,
          HPPercent: "43.21"
        },
        {
          Name: '木人D',
          HateRate: 22,
          HPPercent: "100.00"
        },
      ]
    }
  }
};

var aggrolist = new Vue({
  el: '#aggrolist',
  data: {
    updated: false,
    locked: false,
    collapsed: false,
    encounter: null,
    combatants: null
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
    },
    updateState: function(e) {
      this.locked = e.detail.isLocked;
    },
    toggleCollapse: function() {
      this.collapsed = !this.collapsed;
    }
  }
});
