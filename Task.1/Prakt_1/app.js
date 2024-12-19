public class TextAnalyzer {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        System.out.println("Введіть текст:");
        String text = scanner.nextLine();

        System.out.println("\nВиберіть операцію:");
        System.out.println("1. Пошук слова");
        System.out.println("2. Заміна слова");
        System.out.println("3. Підрахунок кількості слів");

        int choice = scanner.nextInt();
        scanner.nextLine(); // Очистка після введення числа

        switch (choice) {
            case 1 -> {
                System.out.println("Введіть слово для пошуку:");
                String wordToFind = scanner.nextLine();

                Predicate<String> searchWord = word -> text.contains(word);
                boolean found = searchWord.test(wordToFind);

                if(found) {
                    System.out.println("Слово знайдено в тексті.");
                } else {
                    System.out.println("Слово не знайдено в тексті.");
                }
            }
            case 2 -> {
                System.out.println("Введіть слово, яке потрібно замінити:");
                String wordToReplace = scanner.nextLine();
                System.out.println("Введіть нове слово:");
                String newWord = scanner.nextLine();

                BiFunction<String, String, String> replaceWord = (oldWord, newW) -> text.replace(oldWord, newW);
                String updatedText = replaceWord.apply(wordToReplace, newWord);

                System.out.println("Оновлений текст: " + updatedText);
            }
            case 3 -> {
                Function<String, Integer> countWords = txt -> txt.split("\\s+").length;
                int wordCount = countWords.apply(text);

                System.out.println("Кількість слів у тексті: " + wordCount);
            }
            default -> System.out.println("Неправильний вибір операції.");
        }

        scanner.close();
    }
}