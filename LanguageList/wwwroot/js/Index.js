$(function () {
    // デフォルトで表示する要素を指定
    $('.showDetail').show();
    $('.showForm').hide();
    $('.submit').hide();

    // 編集および中止リンクが押下
    $('.edit').click(function () {

        var index = $('.edit').index(this);

        // 要素の表示を切り替える
        $('.showDetail').eq(index).toggle();
        $('.showForm').eq(index).toggle();
        $('.submit').eq(index).toggle();
        if ($(".edit").html() === "編集") {
            $(".edit").html("中止");
        } else {
            $(".edit").html("編集");
        }
    });
});

// 確認ダイアログ
function submitCheck() {
    if (window.confirm('削除してよろしいですか。')) {
        return true;
    } else {
        return false;
    }
}