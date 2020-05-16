@objects
  input             css      input[name=q]
  submit            xpath      //div[contains(@class,'FPdoLc')]/center/input[@name='btnK']

# concrete layout tests

= Search dfd visible =
  @on desktop
    input:
        above submit

= Search  visible =
  @on mobile
    input:
        above submit