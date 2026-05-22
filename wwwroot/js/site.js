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

// Profile interactions: avatar edit preview, save toast, and switch animation
document.addEventListener('DOMContentLoaded', () => {
	const avatarBtn = document.getElementById('avatarEditBtn');
	const avatarImg = document.querySelector('.profile-avatar');
	const saveBtn = document.getElementById('saveProfileBtn');

	if (avatarBtn && avatarImg) {
		avatarBtn.addEventListener('click', () => {
			const input = document.createElement('input');
			input.type = 'file';
			input.accept = 'image/*';
			input.onchange = (e) => {
				const file = e.target.files && e.target.files[0];
				if (!file) return;
				const reader = new FileReader();
				reader.onload = (ev) => {
					avatarImg.src = ev.target.result;
					avatarImg.classList.add('avatar-pulse');
					setTimeout(() => avatarImg.classList.remove('avatar-pulse'), 1800);
				};
				reader.readAsDataURL(file);
			};
			input.click();
		});
	}

	if (saveBtn) {
		saveBtn.addEventListener('click', () => {
			const toast = document.createElement('div');
			toast.className = 'save-toast';
			toast.textContent = 'Profile saved';
			document.body.appendChild(toast);
			setTimeout(() => {
				toast.style.opacity = '0';
				toast.style.transform = 'translateY(8px)';
			}, 1400);
			setTimeout(() => document.body.removeChild(toast), 2000);
		});
	}

	// Animate custom switch toggles to give immediate feedback
	document.querySelectorAll('.custom-switch').forEach((el) => {
		el.addEventListener('change', () => {
			el.classList.add('switch-anim');
			setTimeout(() => el.classList.remove('switch-anim'), 420);
		});
	});
});
});
