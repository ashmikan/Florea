// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

document.addEventListener('DOMContentLoaded', () => {
	const moodButtons = document.querySelectorAll('.mood-chip');
	const title = document.getElementById('bouquetTitle');
	const description = document.getElementById('bouquetDescription');
	const price = document.getElementById('bouquetPrice');
	const image = document.getElementById('bouquetImage');

	if (!moodButtons.length || !title || !description || !price || !image) {
		return;
	}

	moodButtons.forEach((button) => {
		button.addEventListener('click', () => {
			moodButtons.forEach((item) => item.classList.remove('active'));
			button.classList.add('active');

			title.textContent = button.dataset.title || title.textContent;
			description.textContent = button.dataset.description || description.textContent;
			price.textContent = button.dataset.price || price.textContent;
			image.style.backgroundImage = `url('${button.dataset.image || ''}')`;
			image.style.transform = 'scale(1.01)';

			window.setTimeout(() => {
				image.style.transform = 'scale(1)';
			}, 180);
		});
	});
});
