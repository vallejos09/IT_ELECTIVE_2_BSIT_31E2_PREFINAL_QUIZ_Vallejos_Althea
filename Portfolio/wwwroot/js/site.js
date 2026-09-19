(function () {
    function markMissing(img) {
        var box = img.closest('.thumb');
        if (box) { box.classList.add('is-missing'); img.remove(); }
    }

    // Missing thumbnail -> gradient placeholder
    document.addEventListener('error', function (e) {
        if (e.target && e.target.tagName === 'IMG') markMissing(e.target);
    }, true);
    document.querySelectorAll('.thumb img').forEach(function (img) {
        if (img.complete && img.naturalWidth === 0) markMissing(img);
    });

    // Show comment timestamps in the visitor's local time
    document.querySelectorAll('time[data-local]').forEach(function (t) {
        var d = new Date(t.getAttribute('datetime'));
        if (!isNaN(d)) t.textContent = d.toLocaleString([], { dateStyle: 'medium', timeStyle: 'short' });
    });
})();