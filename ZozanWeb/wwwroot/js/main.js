function changeReplayReview(channelName){
    $.ajax({
        data: { c: channelName },
        url: 'Home/getLastReplaysFromChannel',
        success: function (data) {
            
        }
    })
};





