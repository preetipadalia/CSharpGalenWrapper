@objects
  input             css      input[name=q]
  submit            xpath      //div[contains(@class,'FPdoLc')]/center/input[@name='btnK']

# concrete layout tests

= Search input visible =
  @on mobile,desktop
    input:
        above submit