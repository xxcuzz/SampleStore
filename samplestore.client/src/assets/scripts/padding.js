document.addEventListener('DOMContentLoaded', () => {
  const header = document.querySelector('.banner-menu');
  const content = document.querySelector('.posthuman-image-container');

  function setContentPadding() {
    if (header && content) {
      const headerHeight = header.offsetHeight;
      content.style.paddingTop = `${headerHeight}px`;
    }
  }

  setContentPadding();
  window.addEventListener('resize', setContentPadding);
});
