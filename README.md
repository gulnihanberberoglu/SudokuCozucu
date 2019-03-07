<p class="unchanged rich-diff-level-one"><span style="text-decoration: underline;"><strong>MULTİ THREAD KULLANARAK SUDOKU &Ccedil;&Ouml;ZME</strong></span></p>
<p class="unchanged rich-diff-level-one"><strong>&Ouml;zet:</strong></p>
<p class="unchanged rich-diff-level-one"><em>Projede multi thread yapısı kullanılarak sudoku tasarladı. Verilen 9x9 sudoku &uuml;zerinden &ccedil;&ouml;z&uuml;m&uuml;n bulunması hedeflendi. Satır, s&uuml;tun, grup adında &uuml;&ccedil; tane thread kullanıldı birisi satır satır bakıyor diğeri s&uuml;tun s&uuml;tun geziyor &uuml;&ccedil;&uuml;nc&uuml;s&uuml; de 3x3 l&uuml;k karede geziniyor. Thread kullanılmasının sebebi eşzamanlı olarak farklı h&uuml;crelerden &ccedil;&ouml;z&uuml;me başlanacak olmasıdır.</em></p>
<p class="unchanged rich-diff-level-one"><em>Proje file, about, new game, solve, clear, list kısımlarından oluşmaktadır. File; newgame yani yeni oyun başlatır. Quit; projeden &ccedil;ıkıs sağlar. Solve adım adım thread kullanıldığı kısım adım adım &ccedil;&ouml;z&uuml;m bulur. Clear sudokuyu temizler. List de threadlarin &ccedil;alışma hızının karşılaştırıldıgı yerdir.</em></p>
<p class="unchanged rich-diff-level-one"><strong>Genel Yapı:</strong></p>
<p class="unchanged rich-diff-level-one"><em>Program Windows Form Application uygulaması olarak geliştirilmiştir.</em></p>
<p class="unchanged rich-diff-level-one"><em>ToolStripMenuItem i&ccedil;inde new game, solve, clear, timer kısımları vardır. New game kısmı .txt uzantılı dosyayı &ccedil;ağırıyor open file dialog da, solve kısmı threadin &ccedil;&ouml;z&uuml;m bulduğu yer adım adım, clear kısmı sudoku table ı siliyor ve timer kısmında da threadin calışma s&uuml;resini g&ouml;steriyor.</em></p>
<p class="unchanged rich-diff-level-one"><em>Ve .txt uzantılı dosyayı aynı ipucları sudokunun &uuml;zerinde g&ouml;r&uuml;l&uuml;yor. Ardında da &ccedil;&ouml;z&uuml;me hazır.</em></p>
<p class="unchanged rich-diff-level-one"><em>İpu&ccedil;ları gelen sudokunun &ccedil;&ouml;z&uuml;m aşamasına gelindi. Solve tuşuna basarak bu islem ger&ccedil;ekleştiriliyor.</em></p>
<p class="unchanged rich-diff-level-one"><em>Clear butonu t&uuml;m sudoku tahtasındakilerı siliyor.Time zaman tutuyor.</em></p>
<p class="unchanged rich-diff-level-one"><em>About kısmında sudoku nedır butonuna basınca ayrı bır form da sudokunun kuralları &ccedil;ıkıyor.</em></p>
<p class="unchanged rich-diff-level-one"><em>About kısmında hakkında kısmında projeyı yapan kişiler hakkında iletişim bilgileri yer alıyor.</em></p>
<p class="unchanged rich-diff-level-one"><em>Son olarak da &uuml;&ccedil; threadin de calışmasını aynı anda g&ouml;sterildiğinde hızına g&ouml;re kim hızlıysa zaman bittiği anda o kalır.</em></p>
<p class="unchanged rich-diff-level-one"><strong>Sonu&ccedil;:</strong></p>
<p class="unchanged rich-diff-level-one">Sudoku multıthread projesi , aynı anda bir&ccedil;ok farklı noktadan 3 thread ile &ccedil;&ouml;z&uuml;m sunabilmektedir. Normal sudokulara oranla senkronızasyon sağlar.</p>
<p class="unchanged rich-diff-level-one">&nbsp;</p>
