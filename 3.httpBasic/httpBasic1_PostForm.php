<!DOCTYPE html>
<!-- Post-->
<!-- 毎回C#でクライアントを作るのは面倒なので、phpでフォームを作成-->
<html lang="ja">
    <head>
        <meta charset="utf-8">
        <title>入力フォーム(POST)</title>
    </head>
    <body>
        <p>POSTメソッド</p>
        <form method="post" action="URL">
        <li><label>第一引数：<input type name="first"></label></li>
        <li><label>第二引数：<input type="text" name="second"></label></li>
        <li><input type="submit" value="送信"></label></li>
        </form>
    </body>
</html>